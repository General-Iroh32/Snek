using Microsoft.EntityFrameworkCore;
using Snek.Core.Models;

namespace Snek.Infrastructure.Persistence;

public sealed class SeedService(IDbContextFactory<SnekDbContext> contextFactory)
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        if (await HasExistingDataAsync(context, cancellationToken))
        {
            return;
        }

        var dzovani = new Mitwirkende { Id = 1, Vorname = "Dzovani", Nachname = "Koller" };
        var florian = new Mitwirkende { Id = 2, Vorname = "Florian", Nachname = "Kozak" };
        var karl = new Mitwirkende { Id = 3, Vorname = "Karl-Gabriel", Nachname = "Jimenez" };
        var jonas = new Mitwirkende { Id = 4, Vorname = "Jonas", Nachname = "Taferner" };
        var oliver = new Mitwirkende { Id = 5, Vorname = "Oliver", Nachname = "Mate" };

        context.Arbeiten.AddRange(
            CreateWork(1, "PRE bezogen", dzovani, 15, 13, 57),
            CreateWork(2, "POS bezogen", florian, 13, 26, 13),
            CreateWork(3, "PRE bezogen", karl, 14, 35, 16),
            CreateWork(4, "POS bezogen", jonas, 13, 45, 37),
            CreateWork(5, "PRE bezogen", oliver, 15, 50, 14));

        await context.SaveChangesAsync(cancellationToken);
    }

    private static Arbeiten CreateWork(
        int id,
        string art,
        Mitwirkende mitwirkende,
        int stunden,
        int minuten,
        int sekunden) =>
        new()
        {
            Id = id,
            Art = art,
            Mitwirkende = [mitwirkende],
            Zeiten =
            [
                new Zeiten
                {
                    Id = id,
                    Stunden = stunden,
                    Minuten = minuten,
                    Sekunden = sekunden
                }
            ]
        };

    private static async Task<bool> HasExistingDataAsync(
        SnekDbContext context,
        CancellationToken cancellationToken) =>
        await context.Mitwirkende.AnyAsync(cancellationToken)
        || await context.Arbeiten.AnyAsync(cancellationToken)
        || await context.Zeiten.AnyAsync(cancellationToken);
}
