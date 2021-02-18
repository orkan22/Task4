using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var successResult = false;
            while (!successResult || InputOutput.IsRepeatGame())
            {
                Console.WriteLine("The quiz has started.");
                Console.WriteLine("Try to guess the conceived number - input the number:");

                var myQuiz = new Quiz();
                successResult = false;

                while (!successResult)
                {
                    var inputValue = Console.ReadLine();
                    successResult = myQuiz.IsExactMath(inputValue, out string message);
                    Console.WriteLine(message);
                }
                Console.WriteLine($"To start the game again press the {InputOutput.restartGameKey} key or press any key for Exit");
            }
        }
    }
}

