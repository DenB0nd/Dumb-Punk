using System.Linq;
using TextGeneration;
using Xunit;

namespace Tests;

// TODO: ?? ???????? ? ?????? ?????!
public class LibraryTests
{
    [Fact]
    public void Test_TokenizedLibrary_Empty()
    {
        TokenizedLibrary library = new TokenizedLibrary("");
        Assert.False(library.Dictionary.Any());
    }

    [Fact]
    public void Test_TokenizedLibrary_WhiteSpace()
    {
        TokenizedLibrary library = new TokenizedLibrary(" ");
        Assert.False(library.Dictionary.Any());
    }

    [Theory]
    [InlineData("ping pong", 2)]
    [InlineData("ping, pong", 3)]
    [InlineData("pog. pog. pog.", 2)]
    [InlineData("The Dark Tower: The Gunslinger", 5)]
    [InlineData("The: Dark Tower : The Gunslinger", 5)]
    public void Test_TokenizedLibrary_Input_Data(string text, int expected)
    {
        TokenizedLibrary library = new TokenizedLibrary(text);
        Assert.Equal(expected, library.Dictionary.Count);
    }

    [Fact]
    public void Test_DefaultLibrary_Empty_And_WhiteSpace()
    {
        DefaultLibrary library = new DefaultLibrary(" ");
        Assert.Single(library.Dictionary);
        Assert.Equal(string.Empty, library.Dictionary.First());
    }


    [Theory]
    [InlineData("ping pong", 2)]
    [InlineData("ping, pong", 2)]
    [InlineData("pog. pog. pog.", 1)]
    [InlineData("The Dark Tower: The Gunslinger", 4)]
    [InlineData("The: Dark Tower : The Gunslinger", 6)]

    public void Test_DefaultLibrary_InputData(string text, int expected)
    {
        DefaultLibrary library = new DefaultLibrary(text);
        Assert.Equal(expected, library.Dictionary.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1, "a")]
    [InlineData(2, "a", "b")]
    [InlineData(3, "a", "b", "c")]
    public void Test_SentenceGenerator_Count(int count, params string[] strings)
    {
        DefaultLibrary defaultLibrary = new DefaultLibrary(strings);
        SentenceGenerator sentenceGenerator = new SentenceGenerator();
        string result = sentenceGenerator.Generate(defaultLibrary, count: count);
        Assert.Equal(count, result.Split('\n').Length);
    }
}
