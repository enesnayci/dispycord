using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace GalacticBot
{
    public class CommandHandler
    {
        //CommandHandle için client ve command nesnesi gerekiyor.
        private readonly DiscordSocketClient client;
        private readonly CommandService commands;
        //Constructor ile client ve command nesnelerinin içi doldurulacak.
        public CommandHandler(DiscordSocketClient _client, CommandService _commands)
        {
            client = _client;
            commands = _commands;
        }
        //Komutun yapılandırılması.
        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;

            await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }
        //Client dan gelen mesajın yakalanması,kontrollerden geçmesi ve son olarak komutun çalıştırılması.
        private async Task HandleCommandAsync(SocketMessage MessageParam)
        {
            var message = MessageParam as SocketUserMessage;
            if (message == null) return;

            int ArgPos = 0;

            // Prefix ve Author kontrolüne göre return edilecek. 
             if (!(message.HasCharPrefix('?', ref ArgPos) || message.HasMentionPrefix(client.CurrentUser, ref ArgPos)) || message.Author.IsBot) return;

            var context = new SocketCommandContext(client, message);

            await commands.ExecuteAsync(
                context: context,
                argPos: ArgPos,
                services: null
                );
        }
    }
}