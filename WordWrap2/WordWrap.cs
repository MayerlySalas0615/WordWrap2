using AwesomeAssertions;

namespace WordWrap2;

public class WordWrap
{
    [Fact]
    public void a()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }
    private static string Wrap(string text, int col)
    {
        throw new Exception();
    }
}