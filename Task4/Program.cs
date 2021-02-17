using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("The quiz has started. Try to guess the conceived number");

                Quiz myQuiz = new Quiz();
                var inputNumber = InputOutput.GetInputNumber();

                while (!myQuiz.IsExactMath(inputNumber, out bool isResultGreatOrLess))
                {
                    Console.WriteLine(isResultGreatOrLess ? "The entered number is greater than the conceived number":
                                                            "The entered number is less than the conceived number");
                    inputNumber = InputOutput.GetInputNumber();
                }

                Console.WriteLine($"Congratulation! The conceived number is {inputNumber}");

                if (!InputOutput.IsRepeatGame()) break;
            }
        }
    }
}
