using CointelegraphScarp.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            var elements = driver.FindElements(By.ClassName("post-card-inline__title"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            foreach (WebElement element in elements)
            {
                news.Add(new News()
                {
                    Head = element.Text,
                    Contents = GetContents(element, driver)
                });
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
