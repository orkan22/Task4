using System;
using Xunit;
using Task4;

namespace Task4Tests
{
    public class QuizTest
    {
        [Theory]
        [InlineData( "5", Quiz.State.isEqual)]
        [InlineData("4", Quiz.State.Less )]
        [InlineData("6", Quiz.State.Greater)]
        [InlineData(null, Quiz.State.Error)]
        [InlineData("-99", Quiz.State.Less )]
        public void IsExactMath_stringValue_ReturnsResultCorrectly(string inputValue, Quiz.State expected)
        {
            var myClass = new Quiz(5);
            _ = myClass.IsExactMath(inputValue, out Quiz.State state);
            Assert.Equal(expected, state );
        }
    }
}
