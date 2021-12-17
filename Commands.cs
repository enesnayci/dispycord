using System;
using System.Threading.Tasks;
using Discord.Commands;

public class General : ModuleBase<SocketCommandContext>
{
    [Command("selam")]
    [Summary("Selamla")]

    public async Task selamBackAsync(){
        System.Console.WriteLine("Selam --used");
        await Context.Channel.SendMessageAsync("Selam dostum :)");
    }
}
public class GG : ModuleBase<SocketCommandContext>
{
    [Command("GG")]
    [Summary("GoodGame")]

    public async Task GgBackAsync(ulong id){
        
        await Context.Channel.DeleteMessageAsync(id);
    }
}