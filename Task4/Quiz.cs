using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Quiz
    {
        private int _secretNumber;
        private const int _minValue = 0;
        private const int _maxValue = 100;

        public Quiz()
        {
            SetSecretNumber();
        }

        public Quiz(int secretNumber)
        {
            _secretNumber= secretNumber;
        }

        public bool IsExactMath (int number, out bool isGreater)
        {
            isGreater = false;
            if (_secretNumber == number) return true;
            if (_secretNumber > number) isGreater = true;
            if (_secretNumber < number) isGreater = false;
            return false;
        }

        private void SetSecretNumber()
        {
            var randomValue = new Random();
            _secretNumber = randomValue.Next(_minValue, _maxValue + 1);
        }
    }
}
