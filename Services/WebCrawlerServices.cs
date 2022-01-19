using CointelegraphScarp.Entities;
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
            var elements = driver.FindElements(By.XPath("/html[1]/body[1]"));

            foreach (WebElement element in elements)
            {
                element.FindElement(By.XPath("post-card-inline__title-link")).Click(); 
                News item = new News();
                item.Head = driver.FindElement(By.ClassName("post__title")).Text;//post__title
                item.Contents = driver.FindElement(By.ClassName("post-content")).Text;
                news.Add(item);
                driver.Navigate().GoToUrl("https://cointelegraph.com/tags/bitcoin");
            }
            return news;   
        }

        public string  GetContents(IWebElement webElement,WebDriver driver)
        {
            webElement.Click();
            var content = driver.FindElement(By.ClassName("post-content"));
            return content.Text;  
        }
    }
}
