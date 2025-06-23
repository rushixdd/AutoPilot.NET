using AutoPilot.Framework.Interfaces;

namespace demoqa.Tests.Base.Web
{
    internal abstract class DemoQABase
    {
        protected IWebAutomationProvider Provider;
        public DemoQABase(IWebAutomationProvider webAutomationProvider)
        {
            this.Provider = webAutomationProvider;
        }
    }
}
