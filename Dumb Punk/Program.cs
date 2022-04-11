
// See https://aka.ms/new-console-template for more information
using MarkovChain;
using System.Diagnostics;
using TextGeneration;

Console.WriteLine("Hello, World!");

MarkovChain<int> cd = new MarkovChain<int>(new int[] {});
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
stopwatch = Stopwatch.StartNew();

string str1 = new string(str.Where(c => !char.IsPunctuation(c) && !c.Equals(',')).ToArray());
var arr = str1.Split(' ').Select(s => s.Trim());

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();

var t = new MarkovChain<string>(arr);

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();
TextGenerator text = TextGenerator.CreateBuilder()
                                  .SetLibrary(new DefaultLibrary(str))
                                  .UsingAlgorithm(new MarkovAlgorithm())
                                  .Build();

Console.WriteLine(text.Generate("Я", 50));

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);


