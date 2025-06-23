namespace AutoPilot.Framework.Core
{
    public class MobileSettings
    {
        public string PlatformName { get; set; }
        public string DeviceName { get; set; }
        public string AppPath { get; set; }
    }

    public class FrameworkSettings
    {
        public string Platform { get; set; }
        public string Framework { get; set; }
        public string Browser { get; set; }
        public string BaseUrl { get; set; }
        public string ApiBaseUrl { get; set; }
        public MobileSettings Mobile { get; set; }
    }
}