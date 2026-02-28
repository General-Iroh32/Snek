using System.Globalization;

namespace Snek.Core.Graphs;

public sealed class GraphDocumentSerializer
{
    public string Serialize(GraphDocument document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var lines = new[] { document.Type.ToDisplayName() }
            .Concat(document.Values.Select(value => value.ToString("R", CultureInfo.InvariantCulture)));
        return string.Join(Environment.NewLine, lines) + Environment.NewLine;
    }

    public GraphDocument Deserialize(string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(content);

        var lines = content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (!GraphTypeExtensions.TryParseDisplayName(lines[0], out var type))
        {
            throw new FormatException($"Unsupported graph type '{lines[0]}'.");
        }

        var values = lines.Skip(1).Select(ParseValue).ToArray();
        return new GraphDocument(type, values);
    }

    private static double ParseValue(string value) =>
        double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : throw new FormatException($"'{value}' is not a valid graph value.");
}
