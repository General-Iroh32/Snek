using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Snek.Infrastructure.Persistence;

namespace Snek.Tests.Persistence;

public sealed class SeedServiceTests
{
    [Fact]
    public async Task InitializeAsync_RestoresOriginalDatasetAndIsIdempotent()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync(cancellationToken);
        var options = new DbContextOptionsBuilder<SnekDbContext>().UseSqlite(connection).Options;
        var factory = new TestDbContextFactory(options);
        var initializer = new DatabaseInitializer(factory, new SeedService(factory));

        await initializer.InitializeAsync(cancellationToken);
        await initializer.InitializeAsync(cancellationToken);

        await using var context = new SnekDbContext(options);
        var contributors = await context.Mitwirkende.OrderBy(item => item.Id).ToListAsync(cancellationToken);
        var work = await context.Arbeiten
            .Include(item => item.Mitwirkende)
            .Include(item => item.Zeiten)
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);
        var times = await context.Zeiten.OrderBy(item => item.Id).ToListAsync(cancellationToken);

        Assert.Equal(5, contributors.Count);
        Assert.Equal(
            ["Dzovani Koller", "Florian Kozak", "Karl-Gabriel Jimenez", "Jonas Taferner", "Oliver Mate"],
            contributors.Select(item => item.VollerName));
        Assert.Equal(["PRE bezogen", "POS bezogen", "PRE bezogen", "POS bezogen", "PRE bezogen"],
            work.Select(item => item.Art));
        Assert.All(work, item => Assert.Single(item.Mitwirkende));
        Assert.All(work, item => Assert.Single(item.Zeiten));
        Assert.Equal(5, times.Count);
        Assert.Equal(
            [(15, 13, 57), (13, 26, 13), (14, 35, 16), (13, 45, 37), (15, 50, 14)],
            times.Select(item => (item.Stunden, item.Minuten, item.Sekunden)));
    }

    [Fact]
    public async Task InitializeAsync_DoesNotReplaceExistingUserData()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync(cancellationToken);
        var options = new DbContextOptionsBuilder<SnekDbContext>().UseSqlite(connection).Options;
        var factory = new TestDbContextFactory(options);

        await using (var context = new SnekDbContext(options))
        {
            await context.Database.MigrateAsync(cancellationToken);
            context.Mitwirkende.Add(new() { Vorname = "Eigene", Nachname = "Person" });
            await context.SaveChangesAsync(cancellationToken);
        }

        var initializer = new DatabaseInitializer(factory, new SeedService(factory));
        await initializer.InitializeAsync(cancellationToken);

        await using var verificationContext = new SnekDbContext(options);
        var contributor = await verificationContext.Mitwirkende.SingleAsync(cancellationToken);
        Assert.Equal("Eigene Person", contributor.VollerName);
        Assert.Empty(await verificationContext.Arbeiten.ToListAsync(cancellationToken));
        Assert.Empty(await verificationContext.Zeiten.ToListAsync(cancellationToken));
    }

    private sealed class TestDbContextFactory(DbContextOptions<SnekDbContext> options)
        : IDbContextFactory<SnekDbContext>
    {
        public SnekDbContext CreateDbContext() => new(options);
    }
}
