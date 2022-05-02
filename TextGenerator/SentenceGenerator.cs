using Tools;

namespace TextGeneration
{
    public class SentenceGenerator : IGenerator
    {
        public string Generate(ILibrary library, string start = "", int count = 1)
        {
            return String.Join('\n', library.Dictionary.Shuffle().Take(count));
        }

        
    }
}
