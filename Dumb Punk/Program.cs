
// See https://aka.ms/new-console-template for more information
using Markov_Chain;

Console.WriteLine("Hello, World!");

ChainDictionary<int> cd = new ChainDictionary<int>(new int[] {});


string str = "Как было сказано в самом начале, метод, использующий yield, может возвращать IEnumerable, то есть как бы саму последовательность, а не её итератор. Довольно часто более удобным вариантом может оказаться работа именно с IEnumerable, так как для этого интерфейса есть множество методов расширения, а также присутствует возможность обхода в цикле foreach.";

MarkovChain<string> markov = new MarkovChain<string>(str.Split());

var array = markov.Generate("было", 20);

foreach (var item in array)
{
    Console.WriteLine(item);
}

