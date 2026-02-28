using Microsoft.EntityFrameworkCore;
using Snek.Core.Models;
using Snek.Core.Repositories;

namespace Snek.Infrastructure.Persistence;

public sealed class SqlitePosRepository(IDbContextFactory<SnekDbContext> contextFactory) : IPosRepository
{
    public async Task<IReadOnlyList<Mitwirkende>> GetMitwirkendeAsync(
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Mitwirkende
            .AsNoTracking()
            .OrderBy(item => item.Nachname)
            .ThenBy(item => item.Vorname)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Arbeiten>> GetArbeitenAsync(
        int mitwirkendeId,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Arbeiten
            .AsNoTracking()
            .Where(item => item.Mitwirkende.Any(person => person.Id == mitwirkendeId))
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Zeiten>> GetZeitenAsync(
        int arbeitenId,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Zeiten
            .AsNoTracking()
            .Where(item => item.ArbeitenId == arbeitenId)
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);
    }
}
