using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaperEnigma.Logic;
using PaperEnigma.Logic.Abstractions;
using PaperEnigma.Logic.Enums;
using PaperEnigma.Logic.Rotors;

namespace PaperEnigma.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterType<RotorOne>().Keyed<IRotor>(RotorNumber.RotorOne);
                    builder.RegisterType<RotorTwo>().Keyed<IRotor>(RotorNumber.RotorTwo);
                    builder.RegisterType<RotorThree>().Keyed<IRotor>(RotorNumber.RotorThree);
                    builder.RegisterType<DachpcPaperEnigmaMachine>().As<IPaperEnigmaMachine>();
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}