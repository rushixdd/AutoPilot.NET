using AutoPilot.Framework.Drivers;
using AutoPilot.Framework.Interfaces;

namespace AutoPilot.Framework.Core{ 
    public static class TestSession
    {
        public static FrameworkContext Context { get; set; }
        public static IWebAutomationProvider WebProvider { get; set; }
        public static IMobileAutomationProvider MobileProvider { get; set; }

        public static void Initialize(string configPath)
        {
            Context = FrameworkContext.Initialize(configPath);

            if (Context.Platform.ToLower() == "web")
            {
                WebProvider = ProviderFactory.CreateWebProvider(Context);
            }
            else if (Context.Platform.ToLower() == "mobile")
            {
                MobileProvider = ProviderFactory.CreateMobileProvider(Context);
            }
        }

    }
}