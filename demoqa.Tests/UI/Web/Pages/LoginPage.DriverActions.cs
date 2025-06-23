using AutoPilot.Framework.Interfaces;
using demoqa.Tests.Base.Web;
using OpenQA.Selenium;

namespace demoqa.Tests.UI.Web
{
    internal partial class LoginPage : DemoQABase
    {
        public LoginPage(IWebAutomationProvider webAutomationProvider) : base(webAutomationProvider)
        {
        }

        public void NavigateToLoginPage()
        {
            Provider.Click(this.loginClick);
            //webAutomationProvider.Click(this.newUserClick);
            Provider.EnterText(By.Id("userName"), "testuser");
            Provider.EnterText(By.Id("password"), "Password123!");
            Provider.Click(By.Id("login"));
        }
    }
}
