using AutoPilot.Framework.Interfaces;

namespace AutoPilot.Framework.Core{ 
    public static class TestSession
    {
        public static FrameworkContext Context { get; set; }
        public static IWebAutomationProvider WebProvider { get; set; }
    }
}