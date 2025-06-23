using AutoPilot.Framework.Core;
using AutoPilot.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AutoPilot.Framework.Drivers.MobileDrivers
{
    public class AppiumProvider : IMobileAutomationProvider
    {
        private readonly AndroidDriver _driver;

        public AppiumProvider(string deviceName, string mobilePlatform, string appPath)
        {
            var options = new AppiumOptions();
            options.PlatformName = deviceName;
            options.AddAdditionalAppiumOption("deviceName", mobilePlatform);
            options.AddAdditionalAppiumOption("app", appPath);
            options.AddAdditionalAppiumOption("automationName", "UiAutomator2");

            try
            {
                _driver = new AndroidDriver(
                    new Uri("http://localhost:4723/wd/hub"), options, TimeSpan.FromSeconds(180));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Appium session could not be started. Make sure Appium server is running.", ex);
            }
        }

        public void LaunchApp()
        {
            // Already launched via constructor. This method is here for semantic clarity.
        }

        public void Tap(By selector)
        {
            _driver.FindElement(selector).Click();
        }

        public void EnterText(By selector, string text)
        {
            var element = _driver.FindElement(selector);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(By selector)
        {
            return _driver.FindElement(selector).Text;
        }

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
        }
    }
}
