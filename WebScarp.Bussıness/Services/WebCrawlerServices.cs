
using MongoDB.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Bussıness.Services.Interface;
using WebScarp.Common.Settings.Interface;
using WebScarp.Entities.Entites;

namespace WebScarp.Bussıness.Services
{
    public class WebCrawlerServices : IWebCrawlerServices
    {
        private readonly IURLSettings _urlSettings;
        public WebCrawlerServices(IURLSettings urlSettings)
        {
            _urlSettings = urlSettings; 
        }
        public List<News> Scarpe()
        {
           WebDriver driver = new ChromeDriver();
           List<News> news = new List<News>();
           driver.Navigate().GoToUrl(_urlSettings.Url);
           var elements = driver.FindElements(By.XPath(_urlSettings.HtmlURlTag));
           List<string> urls = new List<string>();
           foreach (var element in elements)
               urls.Add(element.GetAttribute("href"));
           foreach (string url in urls)
           {
               driver.Navigate().GoToUrl(url);
               new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               News item = new News();
               item.ID = ObjectId.GenerateNewId();
               item.Head = driver.FindElement(By.ClassName(_urlSettings.TagTittle)).Text;
               item.Contents = driver.FindElement(By.ClassName(_urlSettings.TagContent)).Text;
               news.Add(item);
           }
           driver.Quit();
           return news;
            
        }
    }
}
