using Npgsql;
using System.Diagnostics;
using TextGeneration;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Stopwatch stopwatch = Stopwatch.StartNew();


string conn_param = ""; 
List<string> array = new List<string>() { };
NpgsqlConnection con = new NpgsqlConnection(conn_param);
NpgsqlCommand com = new NpgsqlCommand("select * from hokkubase ORDER BY random()", con);
con.Open();
NpgsqlDataReader reader = com.ExecuteReader();
for(int i = 0; i < 3; i++)
{
    reader.Read();
    array.Add(reader.GetString(0).Trim());
}
con.Close();

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