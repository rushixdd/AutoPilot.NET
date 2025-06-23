using AutoPilot.Framework.Interfaces;
using AutoPilot.Framework.WebDrivers;
using OpenQA.Selenium;

namespace AutoPilot.Framework.Core
{
    public static class ProviderFactory
    {
        public static IWebAutomationProvider CreateWebProvider(FrameworkContext context)
        {
            return context.Framework.ToLower() switch
            {
                "selenium" => new SeleniumProvider(context.Browser),
                "playwright" => new PlaywrightProvider(context.Browser),
                _ => throw new NotSupportedException($"Framework '{context.Framework}' is not supported.")
            };
        }
    }
}
