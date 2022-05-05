using System.Text;

namespace TextGeneration;

public class DefaultMarkovGenerator : IGenerator
{
    public string Generate(ILibrary library, string start = "", int count = 1)
    {
        if (library is not IChainedLibrary)
        {
            return string.Empty;
        }
        return Generate((IChainedLibrary)library, start, count);
    }

    private string Generate(IChainedLibrary library, string start, int lenght)
    {
        ArgumentNullException.ThrowIfNull(start);

        start = start.ToLowerInvariant();
        if (!library.ChainedSource.Links.ContainsKey(start))
        {
            return start;
        }

        StringBuilder result = new StringBuilder(start + ' ');
        string word = start;
        for (int i = 0; i < lenght; i++)
        {
            word = RandomNextCell(library.ChainedSource.Links[word]);
            result.Append(word + ' ');
        }

        return result.ToString();
    }

    private string RandomNextCell(Dictionary<string, int> links)
    {
        int sum = links.Sum(x => x.Value);

        int randomNumber = Random.Shared.Next(1, sum + 1);
        int rangeBottom = 1;
        int rangeTop = 1;

        foreach (KeyValuePair<string, int> entry in links)
        {
            rangeTop += entry.Value;
            if (rangeBottom <= randomNumber && randomNumber <= rangeTop)
            {
                return entry.Key;
            }

            rangeBottom = rangeTop;
        }

        return string.Empty;
    }
}
