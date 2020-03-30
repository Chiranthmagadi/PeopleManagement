using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PeopleManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            RunSeeding(host);
            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            //var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            //using (var scope = scopeFactory.CreateScope())
            //{
            //    var seeder = scope.ServiceProvider.GetService<PeopleSeeder>();
            //    seeder.Seed();
            //}
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //Removing default configuration
            builder.Sources.Clear();
            builder.AddJsonFile("config.json", false, true)
                   .AddEnvironmentVariables();
        }

    }
}
