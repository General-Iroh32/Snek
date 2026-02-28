using Microsoft.EntityFrameworkCore;
using Snek.Core.Models;

namespace Snek.Infrastructure.Persistence;

public sealed class DatabaseInitializer(IDbContextFactory<SnekDbContext> contextFactory)
{
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Database.MigrateAsync(cancellationToken);

        if (await context.Mitwirkende.AnyAsync(cancellationToken))
        {
            return;
        }

        var dzovani = new Mitwirkende { Vorname = "Dzovani", Nachname = "Koller" };
        var florian = new Mitwirkende { Vorname = "Florian", Nachname = "Kozak" };
        var karl = new Mitwirkende { Vorname = "Karl-Gabriel", Nachname = "Jimenez" };
        var jonas = new Mitwirkende { Vorname = "Jonas", Nachname = "Taferner" };
        var oliver = new Mitwirkende { Vorname = "Oliver", Nachname = "Mate" };

        var planning = new Arbeiten
        {
            Art = "PRE bezogen",
            Mitwirkende = [dzovani, florian, karl],
            Zeiten =
            [
                new Zeiten { Stunden = 15, Minuten = 13, Sekunden = 57 },
                new Zeiten { Stunden = 13, Minuten = 26, Sekunden = 13 }
            ]
        };
        var implementation = new Arbeiten
        {
            Art = "POS bezogen",
            Mitwirkende = [dzovani, jonas, oliver],
            Zeiten =
            [
                new Zeiten { Stunden = 14, Minuten = 35, Sekunden = 16 },
                new Zeiten { Stunden = 13, Minuten = 45, Sekunden = 37 },
                new Zeiten { Stunden = 15, Minuten = 50, Sekunden = 14 }
            ]
        };

        context.Arbeiten.AddRange(planning, implementation);
        await context.SaveChangesAsync(cancellationToken);
    }
}
