using AutoPilot.Framework.Interfaces;
using demoqa.Tests.Base;
using demoqa.Tests.UI.Web;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demoqa.Tests.Tests.Web
{
    public class BookStoreTests : BaseTest
    {
        [Test]
        public void AddBookToCollection_ShouldAppearInProfile()
        {
            LoginPage loginPage = new LoginPage(Provider);
            loginPage.NavigateToLoginPage();
        }
    }
}
