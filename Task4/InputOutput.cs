using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal static class InputOutput
    {
        public const ConsoleKey restartGameKey = ConsoleKey.Enter;
        public static bool IsRepeatGame()
        {
            var keyInfo = Console.ReadKey(true);
            return keyInfo.Key == restartGameKey;
        }
    }
}
