using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Q.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("autofac.json");
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices(services => services.AddAutofac())
                .Build();
    }
}
