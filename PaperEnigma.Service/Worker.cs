using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PaperEnigma.Logic.Abstractions;

namespace PaperEnigma.Service
{
    public class Worker : BackgroundService
    {
        private readonly IPaperEnigmaMachine _paperEnigmaMachine;

        public Worker(IPaperEnigmaMachine paperEnigmaMachine)
        {
            _paperEnigmaMachine = paperEnigmaMachine;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Set the Initial Settings or press Y to use MCK: ");
                string initialSetting = Console.ReadLine();
                if (string.IsNullOrEmpty(initialSetting))
                {
                    Console.WriteLine("You must enter an initial setting and it must contain 3 characters.");
                    continue;
                }

                if (string.Equals(initialSetting, "Y", StringComparison.InvariantCultureIgnoreCase))
                    initialSetting = "MCK";
                else if (initialSetting.Length != 3)
                {
                    Console.WriteLine("You must enter an initial setting and it must contain 3 characters.");
                    continue;
                }
                Console.WriteLine("Enter a message: ");
                string message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("You must enter a message to decode.");
                    continue;
                }
                _paperEnigmaMachine.SetInitialSettings(initialSetting.ToUpper());
                string decodedMessage = _paperEnigmaMachine.DecodeMessage(message.ToUpper());
                Console.WriteLine($"Decoded message: {decodedMessage}");
                Console.ReadKey();
            }
            return Task.CompletedTask;
        }
    }
}