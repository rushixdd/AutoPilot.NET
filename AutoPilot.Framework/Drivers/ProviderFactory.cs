using AutoPilot.Framework.Core;
using AutoPilot.Framework.Drivers.MobileDrivers;
using AutoPilot.Framework.Drivers.WebDrivers;
using AutoPilot.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutoPilot.Framework.Drivers
{
    public static class ProviderFactory
    {
        public static IWebAutomationProvider CreateWebProvider(FrameworkContext context)
        {
            return context.Framework.ToLower() switch
            {
                "selenium" => new SeleniumProvider(context.Browser),
                "playwright" => new PlaywrightProvider(context.Browser),
                _ => throw new NotSupportedException("Unsupported framework")
            };
        }

        public static IMobileAutomationProvider CreateMobileProvider(FrameworkContext context)
        {
            return new AppiumProvider(context.DeviceName, context.MobilePlatform, context.AppPath);
        }
    }
}
