using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                do
                {
                    {

                        var minValue = InputOutput.GetMinValue();
                        var maxValue = InputOutput.GetMaxValue();

                        var myQuiz = new Quiz(minValue, maxValue);

                        Console.WriteLine("The quiz has started.");
                        Console.WriteLine("Try to guess the conceived number - input the number:");

                        var successResult = false;

                        while (!successResult)
                        {
                            var inputValue = Console.ReadLine();
                            successResult = myQuiz.IsExactMath(inputValue, out string message);
                            Console.WriteLine(message);
                        }
                        Console.WriteLine($"To start the game again press the {InputOutput.RestartGameKey} key or press any key for Exit");
                    }
                } while (InputOutput.IsRepeatGame());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

