using MarkovChain;

namespace TextGeneration;

public interface IChainedLibrary : ILibrary
{
    public MarkovChain<string> ChainedSource { get; init; }
}
