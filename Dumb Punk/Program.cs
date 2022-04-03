
// See https://aka.ms/new-console-template for more information
using Markov_Chain;

Console.WriteLine("Hello, World!");

ChainDictionary<int> cd = new ChainDictionary<int>(new int[] {});

Console.WriteLine(new Window<int>(new int[] { }).Equals(new Window<int>(new int[] { })));