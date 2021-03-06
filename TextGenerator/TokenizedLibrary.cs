using MarkovChain;
using System.Diagnostics;
using System.Text;
namespace TextGeneration;

public class TokenizedLibrary : IChainedLibrary
{
    public MarkovChain<string> ChainedSource { get; init; }

    public HashSet<string> Dictionary { get; init; }

    public TokenizedLibrary(string source)
    {
        var tokens = Tokenize(source);
        Dictionary = new HashSet<string>(tokens);
        ChainedSource = new MarkovChain<string>(tokens);
    }

    public TokenizedLibrary(IEnumerable<string> tokens)
    {
        ChainedSource = new MarkovChain<string>(tokens);
        Dictionary = new HashSet<string>(tokens);
    }


    // Делим строку на слова и знаки препинания
    // Самый быстрый найденный мной способ (без особых заморачиваний) ~100 мс

    public IEnumerable<string> Tokenize(string source)
    {
        source = source.Replace("\n", " ").Replace("\r", " ");
        IEnumerable<string> tokens = AddWhiteSpaces(source)
            .Split(' ')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s => s.ToLowerInvariant());

        return tokens;
    }

    // Вокруг знаков нужно добавить пробелы, чтобы их можно было удобно отделить

    private string AddWhiteSpaces(string text)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (IsSign(text[i]))
            {
                result.Append($" {text[i]} ");
            }
            else
            {
                result.Append(text[i]);
            }
        }
        return result.ToString();
    }

    private bool IsSign(char symbol) => char.IsSymbol(symbol) || char.IsSeparator(symbol) || char.IsPunctuation(symbol);
}
