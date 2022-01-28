
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CointelegraphScarp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder();
            //var host = BuildConfig(builder);

            //var configuration = builder.Build();
            //Program program = new Program();
            //program.WebCrawler(host);
            //Console.WriteLine("Done..");
        }
        //public async void WebCrawler(IHost host)
        //{
        //    var hst = ActivatorUtilities.CreateInstance<NewsServices>(host.Services);
        //    WebCrawlerServices services = new WebCrawlerServices();
        //    var newsList = services.Scarpe();
        //    if (newsList.Count() > 0)
        //        await hst.CreateMany(newsList);
        //}
        //static IHost BuildConfig(IConfigurationBuilder builder)
        //{
        //    builder.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", true, true)
        //        .Build();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.Configure<DatabaseSettings>(context.Configuration.GetSection(nameof(DatabaseSettings)));
        //            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
        //            services.Configure<URLSettings>(context.Configuration.GetSection(nameof(URLSettings)));
        //            services.AddSingleton<IURLSettings>(sp => sp.GetRequiredService<IOptions<URLSettings>>().Value);
        //            services.AddScoped<NewsServices>();
        //            services.AddScoped<INewsRepository, NewsRepository>();
        //        }).Build();
        //    return host;
        //}

    }
}