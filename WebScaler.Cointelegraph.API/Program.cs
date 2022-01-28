
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebScarp.Bussıness.Repository;
using WebScarp.Bussıness.Repository.Interface;
using WebScarp.Bussıness.Services;
using WebScarp.Bussıness.Services.Interface;
using WebScarp.Common.Settings;
using WebScarp.Common.Settings.Interface;
using WebScarp.DataAccess.DataAccess;
using WebScarp.DataAccess.DataAccess.Interface;

namespace WebScaler.Cointelegraph.API
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
            var webCrawler = host.Services.GetService<IWebCrawlerServices>();
            var newList = webCrawler.Scarpe();
            var newsServices = host.Services.GetService<INewsServices>();
            if(newList.Count()>0)
             await newsServices.CreateMany(newList);
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
                    services.Configure<URLSettings>(context.Configuration.GetSection(nameof(URLSettings)));
                    services.AddSingleton<IURLSettings>(sp => sp.GetRequiredService<IOptions<URLSettings>>().Value);
                    services.AddScoped<INewsServices, NewsServices>();
                    services.AddScoped<INewsContext, NewsContext>();
                    services.AddScoped<IWebCrawlerServices, WebCrawlerServices>();
                    services.AddScoped<INewsRepository, NewsRepository>();
                }).Build();
            return host;
        }

    }
}