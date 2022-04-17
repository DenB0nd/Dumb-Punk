using MarkovChain;

namespace TextGeneration;

public class DefaultLibrary : IChainedLibrary, ITextLibrary
{
    public string Source { get; set; } = string.Empty;

    public MarkovChain<string> ChainedSource { get; set; }

    public HashSet<string> Dictionary { get; private set; }

    public DefaultLibrary(IEnumerable<string> chain)
    {
        ChainedSource = new MarkovChain<string>(chain);
        Dictionary = new HashSet<string>(chain);
    }

    public DefaultLibrary(string source)
    {
        Source = source;
        IEnumerable<string> chain = new string
            (
            source.Where(c => !char.IsPunctuation(c) && !c.Equals(','))
            .ToArray()
            ).Split(' ')
            .Select(s => s.Trim());
        Dictionary = new HashSet<string>(chain);
        ChainedSource = new MarkovChain<string>(chain);
    }
}
