
// See https://aka.ms/new-console-template for more information
using Markov_Chain;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

ChainDictionary<int> cd = new ChainDictionary<int>(new int[] {});
Stopwatch stopwatch = Stopwatch.StartNew();


string str = "";
List<string> list = new List<string>();
List<string> paths = Directory.EnumerateFiles(@"C:\C# и Unity\Dumb Punk\Dumb Punk\bin\Debug\net6.0", "*.txt").ToList();
Parallel.ForEach(paths, current =>
{
    str = File.ReadAllText(current);

    list.Add(str);
});

str = "";

foreach (string item in list)
{
    str += item;
}

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch.Restart();

//str = new string(str.Where(c => !char.IsPunctuation(c) && !c.Equals(',')).ToArray()).ToLower();
MarkovChain<string> markov = new MarkovChain<string>(str.Split(new char[]{' '}).Select(str => str.Replace(" ", "")));

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch.Restart();

var array = markov.Generate("Я", 100);

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch.Restart();

foreach (var item in array)
{
    Console.Write($"{item} ");
}

