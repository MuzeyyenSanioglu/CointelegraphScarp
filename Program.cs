using CointelegraphScarp.DataAccess;
using CointelegraphScarp.Repositories;
using CointelegraphScarp.Services;
using CointelegraphScarp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CointelegraphScarp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            var host = BuildConfig(builder);

            var configuration = builder.Build();
            Program program = new Program();
            program.WebCrawler(host);
            Console.WriteLine("Done..");
        }
        public async void WebCrawler(IHost host)
        {
            var hst = ActivatorUtilities.CreateInstance<NewsServices>(host.Services);
            WebCrawlerServices services = new WebCrawlerServices();
            var newsList = services.Scarpe();
            hst.CreateMany(newsList);
        }
        static IHost BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<DatabaseSettings>(context.Configuration.GetSection(nameof(DatabaseSettings)));
                    services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
                    services.AddScoped<NewsServices>();
                    services.AddScoped<INewsRepository, NewsRepository>();
                }).Build();
            return host;
        }

    }
}