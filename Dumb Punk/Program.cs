using System.Diagnostics;
using TextGeneration;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Stopwatch stopwatch = Stopwatch.StartNew();


using var reader = new StreamReader("hokku.txt");
string str = reader.ReadToEnd();
string[] array = str.Split('\n');




stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();

TextGenerator textGenerator = new TextGeneratorBuilder()
    .UsingLibrary(new DefaultLibrary(array))
    .UsingAlgorithm(new SentenceGenerator())
    .Build();
                                    


Console.WriteLine(textGenerator.Generate(count: 3));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);