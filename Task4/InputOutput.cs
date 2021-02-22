using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Task4
{
    internal static class InputOutput
    {
        public const ConsoleKey RestartGameKey = ConsoleKey.Enter;
        private const string _fileName = "appsettings.json";

        private static readonly IConfiguration _configuration;
        private static readonly int _minValue = 0;
        private static readonly int _maxValue = 100;

        static InputOutput()
        {
            _configuration = ReadConfiguration();
        }

        public static bool IsRepeatGame()
        {
            var keyInfo = Console.ReadKey(true);
            return keyInfo.Key == RestartGameKey;
        }

        public static int GetMinValue()
        {
            return (_configuration != null)
                    ? _configuration.GetValue<int>("MinValue")
                    : _minValue;
        }

        public static int GetMaxValue()
        {
            return (_configuration != null)
                    ? _configuration.GetValue<int>("MaxValue")
                    : _maxValue;
        }

        private static IConfiguration ReadConfiguration()
        {
            var builder = new ConfigurationBuilder();
            if (File.Exists(_fileName))
            {
                builder.AddJsonFile(path: _fileName, optional: true, reloadOnChange: true);
                var configuration = builder.Build();
                return configuration;
            }
            return null;
        }
    }
}
