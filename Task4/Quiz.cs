using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Task4
{
    public class Quiz
    {
        private int _secretNumber;
        private int _minValue = 0;
        private int _maxValue = 100;
        public enum State
        {
            None,
            Error,
            Greater,
            Less,
            isEqual
        }

        public Quiz()
        {
            ReadSettings();
            SetSecretNumber();
        }

        public Quiz(int secretNumber)
        {
            _secretNumber = secretNumber;
        }

        public bool IsExactMath(string inputValue, out string message)
        {
            var successResult = IsExactMath(inputValue, out State state);
            message = GetMessage(state);
            return successResult;
        }

        public bool IsExactMath(string inputValue, out State state)
        {
            state = State.None;

            if (!int.TryParse(inputValue, out int number))
            {
                state = State.Error;
                return false;
            }

            if (_secretNumber == number)
            {
                state = State.isEqual;
                return true;
            };

            state = _secretNumber > number ? State.Less : State.Greater;
            return false;
        }

        private void ReadSettings()
        {
            try
            {
                var builder = new ConfigurationBuilder();
                var fileName = "appsettings.json";
                if (File.Exists(fileName))
                {
                    builder.AddJsonFile(path: fileName, optional: true, reloadOnChange: true);
                    var configuration = builder.Build();
                    if (configuration.GetSection("MinValue").Exists()) int.TryParse(configuration.GetSection("MinValue").Value, out _minValue);
                    if (configuration.GetSection("MaxValue").Exists()) int.TryParse(configuration.GetSection("MaxValue").Value, out _maxValue);
                }
            }
            catch
            {
                
            }
        }

        private void SetSecretNumber()
        {
            var randomValue = new Random();
            _secretNumber = randomValue.Next(_minValue, _maxValue + 1);
        }

        private string GetMessage(State inputValue)
        {
            return inputValue switch
            {
                State.Error   => "Invalid input. Please input number only",
                State.Greater => "The entered number is greater than the conceived number. Please, input the number:",
                State.Less    => "The entered number is less than the conceived number. Please, input the number:",
                State.isEqual => string.Concat($"Congratulation! The conceived number is {_secretNumber}.{Environment.NewLine}",
                                 "Would You like to play again?"),
                _             => string.Empty,
            };
        }
    }
}