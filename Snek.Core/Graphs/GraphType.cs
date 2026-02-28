namespace Snek.Core.Graphs;

public enum GraphType
{
    Line,
    VerticalLine,
    Column,
    Row,
    Pie,
    Doughnut
}

public static class GraphTypeExtensions
{
    public static string ToDisplayName(this GraphType type) => type switch
    {
        GraphType.Line => "Line Series",
        GraphType.VerticalLine => "Vertical Line Series",
        GraphType.Column => "Column Series",
        GraphType.Row => "Row Series",
        GraphType.Pie => "Pie Chart",
        GraphType.Doughnut => "Doughnut",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public static bool TryParseDisplayName(string? value, out GraphType type)
    {
        type = value?.Trim() switch
        {
            "Line Series" => GraphType.Line,
            "Vertical Line Series" => GraphType.VerticalLine,
            "Column Series" => GraphType.Column,
            "Row Series" => GraphType.Row,
            "Pie Chart" => GraphType.Pie,
            "Doughnut" => GraphType.Doughnut,
            _ => (GraphType)(-1)
        };

        return Enum.IsDefined(type);
    }
}
