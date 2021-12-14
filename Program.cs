using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

public class Program
{
	public static Task Main(string[] args) => new Program().MainAsync();
    DiscordSocketClient _client;
    
	public async Task MainAsync()
	{
        _client = new DiscordSocketClient();
        string token;
        _client.Log +=Log;

        token=await File.ReadAllTextAsync(@"..\token.txt");

        await _client.LoginAsync(TokenType.Bot,token);
        await _client.StartAsync();
        await Task.Delay(-1);

    }
        private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}

