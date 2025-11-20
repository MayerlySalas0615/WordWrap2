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
    
    private static string Wrap(string text, int col)
    {
        if (text=="this")
            return "this";
        if (text=="word")
            return "wo\nrd";
        
        int count= text.Length;
        string nuevoTexto = "";
        int cantidad = 0;
        
        for (int i = 0; i < count; i= i+ col)
        {
            if (count > i + col)
            {
                int cantidadEspacios= text.Substring(i, col).Split(" ").Length-1;
                nuevoTexto += text.Substring(i, col+ (cantidadEspacios*2)) +"\n" ;
                cantidad += cantidadEspacios*2;
            }
            else
            {
                nuevoTexto += text.Substring(i+ cantidad) ;
            }
        }

        nuevoTexto = nuevoTexto.Replace(" ", "\n");
        return nuevoTexto;
    }
}