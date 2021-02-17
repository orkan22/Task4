using System;
using Xunit;
using Task4;

namespace Task4Tests
{
    public class QuizTest
    {
        [Theory]
        [InlineData(6, 5, false)]
        [InlineData(4, 5, false)]
        [InlineData(5, 5, true)]

        public void TryGuessNumber_IntValue_ReturnsResultCorrectly(int inputNumber, int conceivedNumber, bool expected)
        {
            var myClass = new Quiz(conceivedNumber);
            Assert.Equal(expected, myClass.IsExactMath(inputNumber, out _));
        }
    }
}
