using Snek.Core.Graphs;

namespace Snek.Tests.Graphs;

public sealed class GraphValueParserTests
{
    private readonly GraphValueParser _parser = new();

    [Fact]
    public void Parse_AcceptsCommaAndPointDecimals()
    {
        var values = _parser.Parse(["1,5", " 2.25 ", null, ""]);

        Assert.Equal([1.5, 2.25], values);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("NaN")]
    [InlineData("Infinity")]
    public void Parse_RejectsInvalidNumbers(string input) =>
        Assert.Throws<FormatException>(() => _parser.Parse([input]));

    [Fact]
    public void Parse_RequiresAtLeastOneValue() =>
        Assert.Throws<FormatException>(() => _parser.Parse([null, " "]));

    [Fact]
    public void ParseText_AcceptsLinesSemicolonsAndDecimalCommas()
    {
        var values = _parser.ParseText("1,5\n2.25; -3");

        Assert.Equal([1.5, 2.25, -3], values);
    }
}
