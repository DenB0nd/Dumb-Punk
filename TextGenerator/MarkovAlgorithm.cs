using MarkovChain;
using System.Text;
namespace TextGeneration
{
    public class MarkovAlgorithm : IGenerationAlgorithm
    {

        public string? Generate(ILibrary library, string start = "", int lenght = 10)
        {
            if(library is IChainedLibrary)
                return Generate((IChainedLibrary)library, start, lenght);
            return null;
        }

        private string Generate(IChainedLibrary library, string start = "", int lenght = 10)
        {
            if (!library.ChainedSource.Links.Any(s => s.BaseElement == start))
                return start;

            StringBuilder result = new StringBuilder();
            string? word = start;
            for (int i = 0; i < lenght; i++)
            {
                word = ChooseRandom(library.
                    ChainedSource.
                    Links.
                    Where(w => w.BaseElement == word));

                if (word is null)
                    return result.ToString();

                result.Append(word);
            }
            return result.ToString();
        }

        private string? ChooseRandom(IEnumerable<Cell<string>> cells)
        {
            if (cells is null)
                return null;

            int rangeStart = 1;
            int rangeEnd = Random.Shared.Next(1, cells.Count());

            foreach (Cell<string> cell in cells)
            {
                if (rangeStart <= cell.Number && rangeEnd <= cell.Number)
                    return cell.LinkedElement;
            }

            return null;
        }

    }
}
