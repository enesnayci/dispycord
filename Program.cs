using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace Dispycord
{
    public class Program 
    {
            DiscordSocketClient _client = new DiscordSocketClient();
            CommandService _commands = new CommandService();

       CommandHandler _deneme ;
	public static Task Main(string[] args) => new Program().MainAsync();        
        public async Task MainAsync()
        {       
            string token="";
            _client.Log +=Log;
            _deneme=new CommandHandler(_client,_commands);
            token=await File.ReadAllTextAsync(@"..\token.txt");

            await _deneme.InstallCommandsAsync();
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
}


