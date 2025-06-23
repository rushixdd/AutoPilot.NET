using AutoPilot.Framework.Interfaces;
using Microsoft.Playwright;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace AutoPilot.Framework.WebDrivers
{
    public class PlaywrightProvider : IWebAutomationProvider
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private IBrowserContext _context;

        public PlaywrightProvider(string browser = "chromium")
        {
            InitAsync(browser).GetAwaiter().GetResult();
        }

        private async Task InitAsync(string browser)
        {
            _playwright = await Playwright.CreateAsync();

            _browser = browser.ToLower() switch
            {
                "firefox" => await _playwright.Firefox.LaunchAsync(new() { Headless = false }),
                "webkit" => await _playwright.Webkit.LaunchAsync(new() { Headless = false }),
                _ => await _playwright.Chromium.LaunchAsync(new() { Headless = false })
            };

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        public void NavigateTo(string url)
        {
            _page.GotoAsync(url).GetAwaiter().GetResult();
        }

        public void Click(By selector)
        {
            _page.ClickAsync(ConvertByToSelector(selector)).GetAwaiter().GetResult();
        }

        public void EnterText(By selector, string text)
        {
            _page.FillAsync(ConvertByToSelector(selector), text).GetAwaiter().GetResult();
        }

        public string GetText(By selector)
        {
            return _page.TextContentAsync(ConvertByToSelector(selector)).GetAwaiter().GetResult();
        }

        public bool IsVisible(By selector)
        {
            return _page.IsVisibleAsync(ConvertByToSelector(selector)).GetAwaiter().GetResult();
        }

        public void Close()
        {
            _browser.CloseAsync().GetAwaiter().GetResult();
            _playwright.Dispose();
        }

        /// <summary>
        /// Converts Selenium's By to Playwright-compatible selector strings.
        /// </summary>
        private string ConvertByToSelector(By by)
        {
            var type = by.GetType().Name;
            var value = by.ToString().Split(new[] { ": " }, StringSplitOptions.None)[1];

            return type switch
            {
                "ById" => $"#{value}",
                "ByClassName" => $".{value}",
                "ByCssSelector" => value,
                "ByXPath" => value,
                "ByName" => $"[name='{value}']",
                "ByTagName" => value,
                _ => throw new NotSupportedException($"Selector type '{type}' is not supported.")
            };
        }
    }
}
