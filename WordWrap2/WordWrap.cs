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
    
    [Fact]
    public void e()
    {
        var result = Wrap("word word", 3);

        result.Should().Be("wor\nd\nwor\nd");
    }
    
    [Fact]
    public void f()
    {
        var result = Wrap("word word", 6);

        result.Should().Be("word\nword");
    }    
    
    public static string resultWrap { get; set; }
    private static string Wrap(string text, int col)
    {
        int count= text.Length;
        string nuevoTexto = "";
        for (int i = 0; i < count; i= i+ col)
        {
            if (count > i + col)
            {
                int cantidadEspacios= text.Substring(i, col).Split(" ").Length-1;
                for (int j = 0; j < cantidadEspacios; j++)
                {
                    var textSplit = text.Substring(i, col).Split(" ")[j];
                    resultWrap += Wrap(textSplit, col) + "\n";
                    i += resultWrap.Length;
                }
                if (count > i + col)
                {
                    nuevoTexto += resultWrap + text.Substring(i, col) +"\n" ;      
                }
                else
                {
                    nuevoTexto += resultWrap + text.Substring(i) ;
                    resultWrap = "";
                }
            }
            else
            {
                nuevoTexto += text.Substring(i) ;
                resultWrap = "";
            }
        }
        nuevoTexto = nuevoTexto.Replace(" ", "");
        return nuevoTexto;
    }
}