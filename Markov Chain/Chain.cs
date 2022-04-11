using System.Collections;

namespace MarkovChain
{
    public class Chain<T> where T : notnull
    {
        public HashSet<Cell<T>> Links { get; private set; } = new();
        public Chain(IEnumerable<T> enumerable)
        {
            AppendToLinks(enumerable);
        }

        public void AppendToLinks(IEnumerable<T> enumerable)
        {
            if (!enumerable.Any())
                return;
            
            var array = enumerable.ToArray();

            for(int i = 0; i < array.Length - 1; i++)
            {
                UpdateLinks(array[i], array[i + 1]);
            }

        }

        private void UpdateLinks(T previous, T current)
        {
            Cell<T>? result = Links.FirstOrDefault(l => l.ConsistOf(previous, current));
            if (result is not null)
                result.IncreaseNumber();
            else
                Links.Add(new Cell<T>(previous, current));
        }

    }
}
