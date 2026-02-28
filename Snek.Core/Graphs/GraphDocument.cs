namespace Snek.Core.Graphs;

public sealed record GraphDocument
{
    public GraphDocument(GraphType type, IEnumerable<double> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        var materializedValues = values.ToArray();
        if (materializedValues.Length == 0)
        {
            throw new ArgumentException("A graph requires at least one value.", nameof(values));
        }

        if (materializedValues.Any(value => double.IsNaN(value) || double.IsInfinity(value)))
        {
            throw new ArgumentException("Graph values must be finite numbers.", nameof(values));
        }

        Type = type;
        Values = materializedValues;
    }

    public GraphType Type { get; }

    public IReadOnlyList<double> Values { get; }
}
