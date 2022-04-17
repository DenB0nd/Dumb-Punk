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
        AppendToLinks(enumerable);
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
            if(array[i] is null)
            {
                continue;
            }
            UpdateLinks(array[i], array[i + 1]);
        }
    }

    private void UpdateLinks(T previous, T current)
    {
        if (Links.ContainsKey(previous))
        {
            if (Links[previous].ContainsKey(current))
            {
                Links[previous][current]++;
            }
            else
            {
                Links[previous].Add(current, 1);
            }
        }
        else
        {
            Links.Add(previous, new Dictionary<T, int> { { current, 1 } });
        }
    }
}
