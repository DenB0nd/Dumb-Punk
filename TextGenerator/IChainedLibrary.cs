using MarkovChain;

namespace TextGeneration
{
    public interface IChainedLibrary : ILibrary
    {
        public Chain<string> ChainedSource { get; set; }
    }
}
