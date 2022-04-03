using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain
{
    public class ChainDictionary<T> where T : notnull
    {
        private Dictionary<Window<T>, Dictionary<Window<T>, int>> _links = new();

        private int WindowSize { get; set; } = 1;

        public ChainDictionary(IEnumerable<T> collection, int windowSize = 1)
        {
            WindowSize = windowSize;
            CreateLinks(collection);
        }

        private IEnumerable<Window<T>> CreateLinks(IEnumerable<T> collection)
        {
            int collectionSize = collection.ToArray().Count();
            int iterator = 0;

            while(iterator + WindowSize < collectionSize)
            {
                yield return new Window<T>(collection.Skip(iterator).Take(WindowSize));
            }
        }

        private void AppendToDictionary(IEnumerable<Window<T>> collection)
        {
            Window<T>[] windows = collection.ToArray();
            Window<T> item;

            
        }
    }
}
