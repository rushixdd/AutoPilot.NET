using AutoPilot.Framework.Core;
using AutoPilot.Framework.Interfaces;
using OpenQA.Selenium;

namespace demoqa.Tests.Base
{
    public abstract class BaseTest
    {
        protected IWebAutomationProvider Provider;
        protected FrameworkContext Context;

        [SetUp]
        public void SetUp()
        {
            Context = FrameworkContext.Initialize("Configuration/globalsettings.json");
            Provider = ProviderFactory.CreateWebProvider(Context);
            Provider.NavigateTo(Context.BaseUrl);
            Provider.Click(By.XPath("//h5[text()='Book Store Application']"));
        }


        [TearDown]
        public void TearDown()
        {
            Provider?.Close();
        }
    }
}
