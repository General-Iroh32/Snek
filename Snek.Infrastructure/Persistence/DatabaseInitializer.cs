using Microsoft.EntityFrameworkCore;

namespace Snek.Infrastructure.Persistence;

public sealed class DatabaseInitializer(
    IDbContextFactory<SnekDbContext> contextFactory,
    SeedService seedService)
{
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Database.MigrateAsync(cancellationToken);
        await seedService.SeedAsync(cancellationToken);
    }
}
