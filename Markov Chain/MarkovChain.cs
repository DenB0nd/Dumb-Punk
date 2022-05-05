using System.Collections.ObjectModel;

namespace MarkovChain;
// baza
public class MarkovChain<T>
    where T : notnull
{
    // Самый быстрый найденный мной способ оперировать цепью Маркова.
    // При изначальном массиве в ~200.000 значений формирует цепь за ~180 мс.
    // TODO: отрефакторить для большей наглядности, инкапсулировать данные и попробовать оптимизировать сильнее
    public ReadOnlyDictionary<T, Dictionary<T, int>> Links { get; init; } = new (new Dictionary<T, Dictionary<T, int>>());

    public MarkovChain(IEnumerable<T> enumerable)
    {
        Links = new (CreateLinks(enumerable));
    }

    public Dictionary<T, Dictionary<T, int>> CreateLinks(IEnumerable<T> enumerable)
    {
        var links = new Dictionary<T, Dictionary<T, int>>() { };
        if (!enumerable.Any())
        {
            return links;
        }
        
        var array = enumerable.ToArray();

        for (int i = 0; i < array.Length - 1; i++)
        {
            if(array[i] is null)
            {
                continue;
            }
            UpdateLinks(array[i], array[i + 1], links);
        }
        return links;
    }

    private void UpdateLinks(T previous, T current, Dictionary<T, Dictionary<T, int>> links)
    {
        if (links.ContainsKey(previous))
        {
            if (links[previous].ContainsKey(current))
            {
                links[previous][current]++;
            }
            else
            {
                links[previous].Add(current, 1);
            }
        }
        else
        {
            links.Add(previous, new Dictionary<T, int> { { current, 1 } });
        }
    }
}
