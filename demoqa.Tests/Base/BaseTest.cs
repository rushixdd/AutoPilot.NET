using AutoPilot.Framework.Core;
using AutoPilot.Framework.Drivers;
using AutoPilot.Framework.Interfaces;
using OpenQA.Selenium;

namespace demoqa.Tests.Base
{
    public abstract class BaseTest
    {
        protected IWebAutomationProvider WebProvider => TestSession.WebProvider;
        protected IMobileAutomationProvider MobileProvider => TestSession.MobileProvider;

        [SetUp]
        public void SetUp()
        {
            TestSession.Initialize("Configuration/globalsettings.json");

            if (TestSession.Context.Platform.ToLower() == "web")
            {
                WebProvider.NavigateTo(TestSession.Context.BaseUrl);
            }
            else if (TestSession.Context.Platform.ToLower() == "mobile")
            {
                MobileProvider.LaunchApp();
            }
        }

        [TearDown]
        public void TearDown()
        {
            WebProvider?.Close();
            MobileProvider?.Close();
        }

    }
}
