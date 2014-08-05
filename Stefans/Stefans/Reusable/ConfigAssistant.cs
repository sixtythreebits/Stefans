using System.Configuration;
using System.Runtime.CompilerServices;

namespace Stefans.Reusable
{
    public static class ConfigAssistant
    {
        private static string GetConfigValue([CallerMemberName]string ConfigKey = "")
        {
            return ConfigurationManager.AppSettings[ConfigKey];
        }

        public static string ProductsFolderRelativePath
        {
            get { return GetConfigValue(); }
        }

        public static string ADNApiUrl
        {
            get { return GetConfigValue(); }
        }

        public static string ADNLogin
        {
            get { return GetConfigValue(); }
        }

        public static string ADNTransactionKey
        {
            get { return GetConfigValue(); }
        }
    }
}