using System.Diagnostics;
using TextGeneration;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Stopwatch stopwatch = Stopwatch.StartNew();

string str = string.Empty;
List<string> list = new List<string>();
List<string> paths = Directory.EnumerateFiles(@"C:\C# и Unity\Dumb Punk\Dumb Punk\bin\Debug\net6.0", "*.txt").ToList();
Parallel.ForEach(paths, current =>
{
    str = File.ReadAllText(current);

    list.Add(str);
});

str = string.Empty;

foreach (string item in list)
{
    str += item;
}

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();
TextGenerator text = TextGenerator.CreateBuilder()
                                  .SetLibrary(new TokenizedLibrary(str))
                                  .UsingAlgorithm(new DefaultMarkovAlgorithm())
                                  .Build();

Console.WriteLine(text.Generate("Я", 50));

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();
text = TextGenerator.CreateBuilder()
                                  .SetLibrary(new DefaultLibrary(str))
                                  .UsingAlgorithm(new DefaultMarkovAlgorithm())
                                  .Build();

Console.WriteLine(text.Generate("Я", 50));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);