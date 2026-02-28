using Snek.Core.Models;
using Snek.Core.Services;

namespace Snek.Tests.Services;

public sealed class TimeSummaryTests
{
    [Fact]
    public void Calculate_NormalizesMinutesAndSeconds()
    {
        var entries = new[]
        {
            new Zeiten { Stunden = 1, Minuten = 50, Sekunden = 45 },
            new Zeiten { Stunden = 2, Minuten = 20, Sekunden = 30 }
        };

        var duration = TimeSummary.Calculate(entries);

        Assert.Equal(new TimeSpan(4, 11, 15), duration);
        Assert.Equal("04:11:15", TimeSummary.Format(duration));
    }
}
