using MarkovChain;

namespace TextGeneration
{
    public class DefaultLibrary : IChainedLibrary, ITextLibrary
    {
        public string Source { get; set; } = "";
        public Chain<string> ChainedSource { get; set; }

        public DefaultLibrary(IEnumerable<string> chain) 
        {
            ChainedSource = new Chain<string>(chain);
        }

        public DefaultLibrary(string source)
        {
            Source = source;
            string str = new string(source.Where(c => !char.IsPunctuation(c) && !c.Equals(',')).ToArray());
            ChainedSource = new Chain<string>(str.Split(' ').Select(s => s.Trim()));
        }
    }
}
