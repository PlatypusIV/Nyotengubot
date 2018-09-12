using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Entrypoint
{
    class Program
    {
        
        DiscordSocketClient _client;

        CommandHandler _commands;


        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {

            //Enter token:
            Console.WriteLine("Please insert the token for Nyotengubot: ");
            string _token = Console.ReadLine();


            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Log;

            _commands = new CommandHandler();

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            await _commands.InstallCommands(_client);

            

            await Task.Delay(-1);


        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }




    }
}
