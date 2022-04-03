namespace Markov_Chain
{
    public class ChainDictionary<T> where T : notnull
    {
        public Dictionary<T, Dictionary<T, int>> Links { get; private set; } = new();

        public ChainDictionary(IEnumerable<T> collection)
        {
            AppendToDictionary(collection);
        }

        private void AppendToDictionary(IEnumerable<T> collection)
        {
            T[] windows = collection.ToArray();

            for(int i = 0; i < windows.Length - 1; i++)
            {
                if(Links.ContainsKey(windows[i]))
                {
                    if (Links[windows[i]].ContainsKey(windows[i + 1]))
                    {
                        Links[windows[i]][windows[i + 1]]++;
                    }
                    else
                    {
                        Links[windows[i]].Add(windows[i + 1], 1);
                    }
                }
                else
                {
                    Links.Add(windows[i], new Dictionary<T, int> { { windows[i+1], 1 } });
                }
            }
        }

    }
}
