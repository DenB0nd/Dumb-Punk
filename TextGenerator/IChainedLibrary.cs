namespace TextGeneration;

using MarkovChain;

public interface IChainedLibrary : ILibrary
{
    public MarkovChain<string> ChainedSource { get; set; }
}
