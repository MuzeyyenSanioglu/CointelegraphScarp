using CointelegraphScarp.Entities;
using MongoDB.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CointelegraphScarp.Services
{
    public  class WebCrawlerServices
    {
        public  List<News> Scarpe()
        {
            WebDriver driver = new ChromeDriver();
            List<News> news = new List<News>();
            driver.Navigate().GoToUrl("https://cointelegraph.com/tags/bitcoin");
            var elements = driver.FindElements(By.XPath("//a[@class='post-card-inline__title-link']"));
            List<string> urls = new List<string>();  
            foreach (var element in elements)
                urls.Add(element.GetAttribute("href"));  
            foreach (string url in urls)
            {
                driver.Navigate().GoToUrl(url);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                News item = new News();
                item.ID = ObjectId.GenerateNewId();
                item.Head = driver.FindElement(By.ClassName("post__title")).Text;
                item.Contents = driver.FindElement(By.ClassName("post-content")).Text;
                news.Add(item);
            }
            driver.Quit();
            return news;   
        }
    }
}
