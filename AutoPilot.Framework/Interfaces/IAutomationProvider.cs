namespace AutoPilot.Framework.Interfaces
{
    public interface IAutomationProvider
    {
        void NavigateTo(string url);         // Web or deep-link
        void Tap(string selector);           // Click or Tap
        void EnterText(string selector, string text);
        string GetText(string selector);
        bool IsVisible(string selector);
        void Close();
    }

}
