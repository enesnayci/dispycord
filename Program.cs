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
            CommandHandler _commandHandler ;
	public static Task Main(string[] args) => new Program().MainAsync();        
        public async Task MainAsync()
        {       
            string token="";
            _client.Log +=Log;
            _commandHandler=new CommandHandler(_client,_commands);
            token=await File.ReadAllTextAsync(@"..\token.txt");

            await _commandHandler.InstallCommandsAsync();
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


