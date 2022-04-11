namespace MarkovChain;

public class MarkovChain<T>
    where T : notnull
{
    // Самый быстрый найденный мной способ оперировать цепью Маркова.
    // При изначальном массиве в ~200.000 значений формирует цепь за ~180 мс.
    // TODO: отрефакторить для большей наглядности, инкапсулировать данные и попробовать оптимизировать сильнее
    public Dictionary<T, Dictionary<T, int>> Links { get; private set; } = new ();

    public MarkovChain(IEnumerable<T> enumerable)
    {
        this.AppendToLinks(enumerable);
    }

    public void AppendToLinks(IEnumerable<T> enumerable)
    {
        if (!enumerable.Any())
        {
            return;
        }

        var array = enumerable.ToArray();

        for (int i = 0; i < array.Length - 1; i++)
        {
            this.UpdateLinks(array[i], array[i + 1]);
        }
    }

    private void UpdateLinks(T previous, T current)
    {
        if (this.Links.ContainsKey(previous))
        {
            if (this.Links[previous].ContainsKey(current))
            {
                this.Links[previous][current]++;
            }
            else
            {
                this.Links[previous].Add(current, 1);
            }
        }
        else
        {
            this.Links.Add(previous, new Dictionary<T, int> { { current, 1 } });
        }
    }
}
