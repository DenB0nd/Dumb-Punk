using System.Diagnostics;
using TextGeneration;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Stopwatch stopwatch = Stopwatch.StartNew();


using var reader = new StreamReader("punk.txt");
string str = reader.ReadToEnd();
str = str.Replace("*", "у");


stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();
TextGenerator text = TextGenerator.CreateBuilder()
                                  .UsingLibrary(new TokenizedLibrary(str))
                                  .UsingAlgorithm(new DefaultMarkovAlgorithm())
                                  .Build();

Console.WriteLine(text.Generate(count: 20));

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch = Stopwatch.StartNew();
text = TextGenerator.CreateBuilder()
                                  .UsingLibrary(new DefaultLibrary(str))
                                  .UsingAlgorithm(new DefaultMarkovAlgorithm())
                                  .Build();

Console.WriteLine(text.Generate(count: 20));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);