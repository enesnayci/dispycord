using Discord;
using Discord.WebSocket;

public class Program
{
	public static Task Main(string[] args) => new Program().MainAsync();

	public async Task MainAsync()
	{
	}
        private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}

