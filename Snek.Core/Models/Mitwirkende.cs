namespace Snek.Core.Models;

public sealed class Mitwirkende
{
    public int Id { get; set; }

    public string Vorname { get; set; } = string.Empty;

    public string Nachname { get; set; } = string.Empty;

    public ICollection<Arbeiten> Arbeiten { get; set; } = [];

    public string VollerName => $"{Vorname} {Nachname}".Trim();
}
