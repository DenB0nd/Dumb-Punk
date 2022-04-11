using MarkovChain;

namespace TextGeneration
{
    public class DefaultLibrary : IChainedLibrary, ITextLibrary
    {
        public string Source { get; set; } = "";
        public MarkovChain<string> ChainedSource { get; set; }

        public DefaultLibrary(IEnumerable<string> chain) 
        {
            ChainedSource = new MarkovChain<string>(chain);
        }

        public DefaultLibrary(string source)
        {
            Source = source;
            string str = new string(source.Where(c => !char.IsPunctuation(c) && !c.Equals(',')).ToArray());
            ChainedSource = new MarkovChain<string>(str.Split(' ').Select(s => s.Trim()));
        }
    }
}
