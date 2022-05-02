using MarkovChain;

namespace TextGeneration;

public class DefaultLibrary : IChainedLibrary, ITextLibrary
{
    public string Source { get; init; } = string.Empty;

    public MarkovChain<string> ChainedSource { get; init; }

    public HashSet<string> Dictionary { get; init; }

    public DefaultLibrary(IEnumerable<string> chain)
    {
        ChainedSource = new MarkovChain<string>(chain);
        Dictionary = new HashSet<string>(chain);
    }

    public DefaultLibrary(string source)
    {
        Source = source;
        IEnumerable<string> chain = source.Split(' ')
            .Select(s => s.Trim());
        Dictionary = new HashSet<string>(chain);
        ChainedSource = new MarkovChain<string>(chain);
    }
}
