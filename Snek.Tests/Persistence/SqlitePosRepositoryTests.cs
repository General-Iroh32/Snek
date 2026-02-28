using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Snek.Core.Models;
using Snek.Infrastructure.Persistence;

namespace Snek.Tests.Persistence;

public sealed class SqlitePosRepositoryTests
{
    [Fact]
    public async Task Queries_FollowContributorAndWorkRelationships()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync(cancellationToken);
        var options = new DbContextOptionsBuilder<SnekDbContext>().UseSqlite(connection).Options;

        await using (var context = new SnekDbContext(options))
        {
            await context.Database.MigrateAsync(cancellationToken);

            var alice = new Mitwirkende { Vorname = "Alice", Nachname = "A" };
            var bob = new Mitwirkende { Vorname = "Bob", Nachname = "B" };
            context.Arbeiten.AddRange(
                new Arbeiten
                {
                    Art = "Analyse",
                    Mitwirkende = [alice],
                    Zeiten = [new Zeiten { Stunden = 1, Minuten = 30 }]
                },
                new Arbeiten
                {
                    Art = "Implementierung",
                    Mitwirkende = [bob],
                    Zeiten = [new Zeiten { Stunden = 2, Minuten = 15 }]
                });
            await context.SaveChangesAsync(cancellationToken);
        }

        var factory = new TestDbContextFactory(options);
        var repository = new SqlitePosRepository(factory);

        var contributors = await repository.GetMitwirkendeAsync(cancellationToken);
        var aliceWork = await repository.GetArbeitenAsync(
            contributors.Single(item => item.Vorname == "Alice").Id,
            cancellationToken);
        var aliceTimes = await repository.GetZeitenAsync(aliceWork.Single().Id, cancellationToken);

        Assert.Equal(2, contributors.Count);
        Assert.Equal("Analyse", Assert.Single(aliceWork).Art);
        Assert.Equal(1, Assert.Single(aliceTimes).Stunden);
    }

    [Fact]
    public async Task Migration_CoversCurrentModel()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync(cancellationToken);
        var options = new DbContextOptionsBuilder<SnekDbContext>().UseSqlite(connection).Options;

        await using var context = new SnekDbContext(options);
        await context.Database.MigrateAsync(cancellationToken);

        var appliedMigrations = await context.Database.GetAppliedMigrationsAsync(cancellationToken);
        Assert.Contains(appliedMigrations, migration => migration.EndsWith("_InitialCreate"));
        Assert.False(context.Database.HasPendingModelChanges());
    }

    private sealed class TestDbContextFactory(DbContextOptions<SnekDbContext> options)
        : IDbContextFactory<SnekDbContext>
    {
        public SnekDbContext CreateDbContext() => new(options);
    }
}
