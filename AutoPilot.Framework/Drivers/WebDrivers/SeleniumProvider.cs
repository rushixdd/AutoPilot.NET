using AutoPilot.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutoPilot.Framework.Drivers.WebDrivers
{
    public class SeleniumProvider : IWebAutomationProvider
    {
        private IWebDriver _driver;

        public SeleniumProvider(string browser)
        {
            _driver = CreateWebDriver(browser);
        }

        private IWebDriver CreateWebDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new NotSupportedException($"Browser '{browser}' is not supported.")
            };
        }

        public void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public void Click(By selector) => _driver.FindElement(selector).Click();

        public void EnterText(By selector, string text)
        {
            var element = _driver.FindElement(selector);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(By selector) => _driver.FindElement(selector).Text;

        public bool IsVisible(By selector)
        {
            try
            {
                return _driver.FindElement(selector).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void Close()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
