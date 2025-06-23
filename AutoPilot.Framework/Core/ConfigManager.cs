using System.Text.Json;

namespace AutoPilot.Framework.Core
{
    public static class ConfigManager
    {
        private static Dictionary<string, JsonElement> _config;
        private static FrameworkSettings _settings;

        public static void Load(string configFilePath)
        {
            var json = File.ReadAllText(configFilePath);
            _settings = JsonSerializer.Deserialize<FrameworkSettings>(json);
        }

        public static FrameworkSettings Settings => _settings;


        public static T Get<T>(string key)
        {
            if (_config.TryGetValue(key, out var value))
            {
                return JsonSerializer.Deserialize<T>(value.GetRawText());
            }
            throw new KeyNotFoundException($"Key '{key}' not found in config.");
        }
    }
}