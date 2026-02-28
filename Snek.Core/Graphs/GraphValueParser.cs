using System.Globalization;

namespace Snek.Core.Graphs;

public sealed class GraphValueParser
{
    public IReadOnlyList<double> Parse(IEnumerable<string?> inputs)
    {
        ArgumentNullException.ThrowIfNull(inputs);

        var values = new List<double>();
        foreach (var input in inputs)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            var normalized = input.Trim().Replace(',', '.');
            if (!double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
                || double.IsNaN(value)
                || double.IsInfinity(value))
            {
                throw new FormatException($"'{input}' ist keine gültige Zahl.");
            }

            values.Add(value);
        }

        return values.Count > 0
            ? values
            : throw new FormatException("Mindestens ein Wert ist erforderlich.");
    }
}
