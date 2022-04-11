using System.Text;
namespace TextGeneration
{
    public class MarkovAlgorithm : IGenerationAlgorithm
    {

        public string? Generate(ILibrary library, string start = "", int lenght = 10)
        {
            ArgumentNullException.ThrowIfNull(nameof(start));
            if (library is IChainedLibrary)
                return Generate((IChainedLibrary)library, start, lenght);
            return null;
        }

        private string Generate(IChainedLibrary library, string start = "", int lenght = 10)
        {
            if (!library.ChainedSource.Links.ContainsKey(start))
                return start;

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
               

            foreach(KeyValuePair<string, int> entry in links)
            {
                rangeTop += entry.Value;
                if(rangeBottom <= randomNumber && randomNumber <= rangeTop)
                    return entry.Key;
                rangeBottom = rangeTop;
            }

            return "";
        }

    }
}
