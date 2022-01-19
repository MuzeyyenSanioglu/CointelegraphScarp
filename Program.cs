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
            Scarpe();
            Console.WriteLine("Done..");
            Console.ReadLine(); 
        }
        public static void Scarpe()
        {
            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cointelegraph.com/tags/bitcoin");
            var elements = driver.FindElements(By.ClassName("post-card-inline__title"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            foreach (WebElement element in elements)
            { 
                Console.WriteLine(element.Text);
                element.Click();//class="post-content"
                var content = driver.FindElement(By.ClassName("post-content"));
                Console.WriteLine(content.Text);

                //Console.WriteLine("HEADER : "+element.ge("post-card-inline__header"));
                //Console.WriteLine("TEXT : "+element.GetAttribute("post-card-inline__text"));
            }


        }
    }
}