using OpenQA.Selenium;

namespace AutoPilot.Framework.Interfaces
{
    public interface IWebAutomationProvider
    {
        void NavigateTo(string url);
        void Click(By selector);
        void EnterText(By selector, string text);
        string GetText(By selector);
        bool IsVisible(By selector);
        void Close();
    }
}