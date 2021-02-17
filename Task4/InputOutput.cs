using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal static class InputOutput
    {
        private const ConsoleKey repeatKey = ConsoleKey.Enter;

        public static int GetInputNumber()
        {
            Console.WriteLine("Please, input the number:");
            string inputValue = Console.ReadLine();
            if (!int.TryParse(inputValue, out int number))
            {
                Console.Write("Invalid input. ");
                return GetInputNumber();
            }
            return number;
        }

        public static bool IsRepeatGame()
        {
            Console.WriteLine($"To start the game again press the {InputOutput.repeatKey} key " +
                                        "or press any key for exit");
            var keyInfo = Console.ReadKey(true);
            return keyInfo.Key == repeatKey;
        }
    }
}
