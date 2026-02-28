using Snek.Core.Graphs;

namespace Snek.Tests.Graphs;

public sealed class GraphDocumentSerializerTests
{
    private readonly GraphDocumentSerializer _serializer = new();

    [Fact]
    public void RoundTrip_PreservesTypeAndValues()
    {
        var original = new GraphDocument(GraphType.Doughnut, [1.25, -2, 3.5]);

        var serialized = _serializer.Serialize(original);
        var restored = _serializer.Deserialize(serialized);

        Assert.Equal(original.Type, restored.Type);
        Assert.Equal(original.Values, restored.Values);
    }

    [Fact]
    public void Deserialize_RejectsUnknownGraphType()
    {
        var exception = Assert.Throws<FormatException>(() => _serializer.Deserialize("Radar\n1\n2\n"));

        Assert.Contains("Unsupported graph type", exception.Message);
    }
}
