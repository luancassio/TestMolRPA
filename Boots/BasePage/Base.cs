using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Boots.BasePage
{
    public class Base
    {
        protected IWebDriver driver;
        public Base()
        {
           driver = new ChromeDriver();
           driver.Manage().Window.Maximize();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public IWebElement AwaitElementAfterClick(By by, int seconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            return wait.Until(driver => driver.FindElement(by));
        }

        public IWebElement ElementIsVisible(By by, int seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void PageUrl(string url) {

            driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindByElement(By by) { 
            return driver.FindElement(by);
        }

        public void ClickBy(By by)
        {
            driver.FindElement(by).Click();
        }

        public IWebElement FindFirstElementEnable(By by)
        {
            var allElements = driver.FindElements(by);
            IWebElement findElementEnable = null;

            foreach (var element in allElements)
            {
                if (element.Displayed)
                {
                    findElementEnable = element;
                    break;
                }
            }
            return findElementEnable;
        }

    }
}
