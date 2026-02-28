using Snek.Core.Models;

namespace Snek.Core.Services;

public static class TimeSummary
{
    public static TimeSpan Calculate(IEnumerable<Zeiten> entries)
    {
        ArgumentNullException.ThrowIfNull(entries);
        return entries.Aggregate(TimeSpan.Zero, (total, entry) => total + entry.Dauer);
    }

    public static string Format(TimeSpan duration) =>
        $"{(int)duration.TotalHours:00}:{duration.Minutes:00}:{duration.Seconds:00}";
}
