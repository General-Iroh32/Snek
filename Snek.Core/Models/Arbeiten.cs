namespace Snek.Core.Models;

public sealed class Arbeiten
{
    public int Id { get; set; }

    public string Art { get; set; } = string.Empty;

    public ICollection<Zeiten> Zeiten { get; set; } = [];

    public ICollection<Mitwirkende> Mitwirkende { get; set; } = [];
}
