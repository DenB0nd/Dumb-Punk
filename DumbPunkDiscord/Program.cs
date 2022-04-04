using Discord;
using Discord.WebSocket;

internal class Program
{
    static private DiscordSocketClient? discord = null;
    static async Task Main(string[] args)
    {
        discord = new DiscordSocketClient();
        discord.MessageReceived += CommandHandler; 
        discord.Log += Log;

        var token = "OTYwNTk2NTA1NjcxMTA2NjMw.YksvNQ.ct5F1WWziSOtsVf-fimko0NFmIY";

        await discord.LoginAsync(TokenType.Bot, token);
        await discord.StartAsync();

        Console.ReadLine();
    }

    private static Task Log(LogMessage arg)
    {
        Console.WriteLine(arg.Message);
        return Task.CompletedTask;
    }

    private static Task CommandHandler(SocketMessage message)
    {
        if(!message.Author.IsBot)
        {
            
            switch(message.Content.ToLower().Trim())
            {
                case "база":
                    {
                        message.Channel.SendMessageAsync("Да, я базированный гигачад шлепа, как ты узнал?");
                        break;
                    }
            }
        }
        return Task.CompletedTask;
    }
}