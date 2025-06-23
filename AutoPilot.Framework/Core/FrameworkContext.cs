namespace AutoPilot.Framework.Core
{
    public class FrameworkContext
    {
        public string Platform { get; set; }
        public string Browser { get; set; }
        public string BaseUrl { get; set; }
        public string ApiBaseUrl { get; set; }
        public string Framework { get; set; }
        public string MobilePlatform { get; set; }
        public string DeviceName { get; set; }
        public string AppPath { get; set; }

        public static FrameworkContext Initialize(string configFilePath)
        {
            ConfigManager.Load(configFilePath);
            var s = ConfigManager.Settings;

            return new FrameworkContext
            {
                Platform = s.Platform,
                Browser = s.Browser,
                BaseUrl = s.BaseUrl,
                ApiBaseUrl = s.ApiBaseUrl,
                Framework = s.Framework,
                MobilePlatform = s.Mobile?.PlatformName,
                DeviceName = s.Mobile?.DeviceName,
                AppPath = s.Mobile?.AppPath
            };
        }
    }
}