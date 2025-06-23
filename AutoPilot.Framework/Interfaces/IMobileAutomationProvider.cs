using OpenQA.Selenium;

namespace AutoPilot.Framework.Interfaces
{
    public interface IMobileAutomationProvider
    {
        void LaunchApp();
        void Tap(By selector);
        void EnterText(By selector, string text);
        string GetText(By selector);
        bool IsVisible(By selector);
        void Close();
    }

}
