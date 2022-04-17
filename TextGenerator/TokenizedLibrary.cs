using MarkovChain;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace TextGeneration;

public class TokenizedLibrary : IChainedLibrary
{
    public MarkovChain<string> ChainedSource { get; set; }

    public HashSet<string> Dictionary => throw new NotImplementedException();

    public TokenizedLibrary(string source)
    {
        ChainedSource = new MarkovChain<string>(Tokenize(source));
    }

    public TokenizedLibrary(IEnumerable<string> tokens)
    {
        ChainedSource = new MarkovChain<string>(tokens);
    }


    // Делим строку на слова и знаки препинания
    // Самый быстрый найденный мной способ (без особых заморачиваний) ~100 мс

    public IEnumerable<string> Tokenize(string source)
    {
        source = source.Replace("\n", "").Replace("\r", "");
        IEnumerable<string> tokens = AddWhiteSpaces(source)
            .Split(' ')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s));

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
