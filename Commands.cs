using System;
using System.Threading.Tasks;
using Discord.Commands;

public class selam : ModuleBase<SocketCommandContext>
{
    [Command("selam")]
    [Summary("Selamla")]

    public async Task selamBackAsync(){
        System.Console.WriteLine("Selam --used");
        await Context.Channel.SendMessageAsync("Selam dostum :)");
    }
}