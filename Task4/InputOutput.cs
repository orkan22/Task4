using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Task4
{
    internal static class InputOutput
    {
        public const ConsoleKey restartGameKey = ConsoleKey.Enter;
        private const string fileName = "appsettings.json";
        private static readonly IConfiguration configuration;

        static InputOutput()
        {
            configuration = ReadConfiguration();
        }

        public static bool IsRepeatGame()
        {
            var keyInfo = Console.ReadKey(true);
            return keyInfo.Key == restartGameKey;
        }

        public static int GetMinValue()
        {
            try
            {
                if (configuration != null) return configuration.GetValue<int>("MinValue");
            }
            catch
            {
            }
            return 0;
        }

        public static int GetMaxValue()
        {
            try
            {
                if (configuration != null) return configuration.GetValue<int>("MaxValue");
            }
            catch
            {
            }
            return 0;
        }

        private static IConfiguration ReadConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder();
                if (File.Exists(fileName))
                {
                    builder.AddJsonFile(path: fileName, optional: true, reloadOnChange: true);
                    var configuration = builder.Build();
                    return configuration;
                }
            }
            catch
            { 
            }
            return null;
        }
    }
}
