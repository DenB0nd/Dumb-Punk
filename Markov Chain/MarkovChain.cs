namespace Markov_Chain
{
    public class MarkovChain<T> where T : notnull
    {
        private ChainDictionary<T> _chainDictionary = new ChainDictionary<T> (new T[] {});

        public MarkovChain(IEnumerable<T> collection)
        {
            _chainDictionary = new ChainDictionary<T> (collection);
        }

        public IEnumerable<T> Generate(T first, int max)
        {
            if (!_chainDictionary.Links.ContainsKey(first))
            {
                yield return first;
                yield break;
            }

            int counter = 0;
            T? item = first;

            while (counter <= max)
            {
                if (!_chainDictionary.Links.ContainsKey(first))
                {
                    yield break;
                }

                item = NextLink(_chainDictionary.Links[item]);

                if(item == null)
                {
                    yield break;
                }

                yield return item;

                counter++;
            }
        }

        private T? NextLink(Dictionary<T, int> links)
        {
            int sum = links.Sum(x => x.Value);

            Random random = new Random();
            int randomNumber = random.Next(1, sum + 1);
            int counter = 1;

            foreach (KeyValuePair<T, int> entry in links)
            {
                if(counter <= randomNumber)
                {
                    return entry.Key;
                }
                counter += entry.Value;
            }

            return default;
        }
    }
}