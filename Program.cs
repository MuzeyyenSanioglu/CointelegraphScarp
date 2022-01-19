using CointelegraphScarp.DataAccess;
using CointelegraphScarp.Repositories;
using CointelegraphScarp.Services;
using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            
            var configuration = builder.Build();
            Program program = new Program();
            program.WebCrawler(configuration);
            Console.WriteLine("Done..");
        }
        public async void WebCrawler(IConfigurationRoot configuration)
        {
            WebCrawlerServices services = new WebCrawlerServices();
            var newsList = services.Scarpe();
            NewsRepository newsRespository = new NewsRepository(GetContext(configuration));
            foreach (var item in newsList)
            {
                await newsRespository.Create(item);
            }
           
        }

        public NewsContext GetContext(IConfigurationRoot configuration)
        {
            return new NewsContext(configuration["ConnectionString"], configuration["DatabaseName"]);
        }
    }
}