namespace Snek.Core.Models;

public sealed class Zeiten
{
    public int Id { get; set; }

    public int Stunden { get; set; }

    public int Minuten { get; set; }

    public int Sekunden { get; set; }

    public int ArbeitenId { get; set; }

    public Arbeiten Arbeiten { get; set; } = null!;

    public TimeSpan Dauer => TimeSpan.FromHours(Stunden)
        + TimeSpan.FromMinutes(Minuten)
        + TimeSpan.FromSeconds(Sekunden);
}
