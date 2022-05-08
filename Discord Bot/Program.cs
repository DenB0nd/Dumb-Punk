using Discord;
using Discord.WebSocket;
using Discord_Bot;
using Npgsql;
using TextGeneration;
using Serilog;
using Serilog.Events;

namespace DumpPunkDiscord;

internal static class Program
{
    private static List<string> hokkuBase = new List<string>() { };

    static async Task Main(string[] args)
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        DiscordSocketClient? discord = new DiscordSocketClient();
        discord.MessageReceived += CommandHandler;
        discord.Log += LogAsync;


        string? token = AppConfig.Token;

        await discord.LoginAsync(TokenType.Bot, token);
        await discord.StartAsync();
        Log.Information("STARTED");
        ReadHokkuBase();

        await Task.Delay(-1);
    }

    static async Task LogAsync(LogMessage message)
    {
        var severity = message.Severity switch
        {
            LogSeverity.Critical => LogEventLevel.Fatal,
            LogSeverity.Error => LogEventLevel.Error,
            LogSeverity.Warning => LogEventLevel.Warning,
            LogSeverity.Info => LogEventLevel.Information,
            LogSeverity.Verbose => LogEventLevel.Verbose,
            LogSeverity.Debug => LogEventLevel.Debug,
            _ => LogEventLevel.Information
        };
        Log.Write(severity, message.Exception, "[{Source}] {Message}", message.Source, message.Message);
        await Task.CompletedTask;
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
            Log.Information("Hokku command executed");
        }

        return Task.CompletedTask;
    }

    static void ReadHokkuBase()
    {
        using NpgsqlConnection con = new NpgsqlConnection(AppConfig.ConnectionString);
        NpgsqlCommand com = new NpgsqlCommand("select * from hokkubase", con);
        con.Open();
        NpgsqlDataReader reader = com.ExecuteReader();
        while (reader.Read())
        {
            hokkuBase.Add(reader.GetString(0).Trim());
        }
        Log.Information("Hokkubase read");
        con.Close();
    }
}