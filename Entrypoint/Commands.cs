using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Entrypoint
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        TalkingLogic tLogic;

        [Command("n")]
        public async Task Respond([Remainder]string whatNyoHears)
        {
            tLogic = new TalkingLogic();

            string nyoResponse = "";

            nyoResponse = await tLogic.responseFromDictTask(whatNyoHears);

            await Context.Channel.SendMessageAsync(nyoResponse);
        }

        [Command("help")]
        public async Task tasukete([Remainder]string rem = "default help text")
        {
            string helpText = "Oh, you require me assistance?\n" +
                "My oh my, how cute... If you must know, you can start your message with *&n* or *@me n* and I'll reply to you.\n" +
                "Ufufuf~ I can tell we're going to have a lot o fun together. See you later...\n";



            await Context.User.SendMessageAsync(helpText);
        }
    }
}
