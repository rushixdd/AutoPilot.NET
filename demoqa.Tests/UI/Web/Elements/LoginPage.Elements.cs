using demoqa.Tests.UI.Web.Elements.Resources;
using OpenQA.Selenium;

namespace demoqa.Tests.UI.Web
{
    internal partial class LoginPage
    {
        By loginClick = By.XPath(LoginPageElements.LoginClick);
        By newUserClick = By.XPath(LoginPageElements.NewUserClick);
    }
}
