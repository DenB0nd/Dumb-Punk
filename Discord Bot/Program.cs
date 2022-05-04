using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore;
using Npgsql;
using System.Text;
using TextGeneration;

namespace DumpPunkDiscord;

internal static class Program
{
    private static List<string> hokkuBase = new List<string>() { };

    static async Task Main(string[] args)
    {
        DiscordSocketClient? discord = new DiscordSocketClient();
        discord.MessageReceived += CommandHandler;
        discord.Log += Log;


        string? token = Environment.GetEnvironmentVariable("TOKEN");

        await discord.LoginAsync(TokenType.Bot, token);
        await discord.StartAsync();
        ReadHokkuBase();

        await Task.Delay(-1);
    }

    static Task Log(LogMessage arg)
    {
        Console.WriteLine(arg.Message);
        return Task.CompletedTask;
    }

    static Task CommandHandler(SocketMessage message)
    {
        if (!message.Author.IsBot && message.Content.ToLower().Trim() == "hokku")
        {
            TextGenerator textGenerator = new TextGeneratorBuilder()
                .UsingLibrary(new DefaultLibrary(hokkuBase))
                .UsingAlgorithm(new SentenceGenerator())
                .Build();

            message.Channel.SendMessageAsync(textGenerator.Generate(count: 3));
        }

        return Task.CompletedTask;
    }

    static void ReadHokkuBase()
    {
        string? databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        if(databaseUrl is null)
        {
            return;
        }

        NpgsqlConnection con = new NpgsqlConnection(ConvertDatabaseUrlToConnectionString(databaseUrl));
        NpgsqlCommand com = new NpgsqlCommand("select * from hokkubase", con);
        con.Open();
        NpgsqlDataReader reader = com.ExecuteReader();
        while (reader.Read())
        {
            try
            {
                hokkuBase.Add(reader.GetString(0).Trim());
            }
            catch
            {
                Console.WriteLine("Reading error");
            }
        }
        Console.WriteLine("Reading completed");
        con.Close();
    }

    static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/')
        };

        return builder.ToString();
    }
}
