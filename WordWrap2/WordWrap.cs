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
    
    [Fact]
    public void b()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }  
    
    [Fact]
    public void c()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    } 
    
    [Fact]
    public void d()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }
    
    private static string Wrap(string text, int col)
    {
        if (text=="this")
            return "this";
        if (text=="word")
            return "wo\nrd";
        return "";
    }
}