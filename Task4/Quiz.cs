using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Task4
{
    public class Quiz
    {
        private int _secretNumber;

        public Quiz(int minValue, int maxValue)
        {
            if (!IsInputValuesValid(minValue, maxValue))
                throw new ArgumentException("Incorrect config file");

            SetSecretNumber(minValue, maxValue);
        }

        public Quiz(int secretNumber)
        {
            _secretNumber = secretNumber;
        }

        public bool IsExactMath(string inputValue, out string message)
        {
            var state = GetCompareState(inputValue);
            message = GetMessage(state);

            return state == State.IsEqual;
        }

        public State GetCompareState(string inputValue)
        {
            if (!int.TryParse(inputValue, out int number))
                return State.Error;

            if (_secretNumber == number)
                return State.IsEqual;

            return _secretNumber > number
                ? State.Less :
                State.Greater;
        }

        private bool IsInputValuesValid(int minValue, int maxValue)
        {
            return (maxValue > minValue && minValue >= 0);
        }

        private void SetSecretNumber(int minValue, int maxValue)
        {
            var randomValue = new Random();
            _secretNumber = randomValue.Next(minValue, maxValue + 1);
        }

        private string GetMessage(State inputValue)
        {
            return inputValue switch
            {
                State.Error => "Invalid input. Please input number only",
                State.Greater => "The entered number is greater than the conceived number. Please, input the number:",
                State.Less => "The entered number is less than the conceived number. Please, input the number:",
                State.IsEqual => string.Concat($"Congratulation! The conceived number is {_secretNumber}.{Environment.NewLine}",
                                 "Would You like to play again?"),
                _ => string.Empty,
            };
        }
    }
}