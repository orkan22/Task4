using System;
using Xunit;
using Task4;

namespace Task4Tests
{
    public class QuizTest
    {
        [Theory]
        [InlineData( "5", State.IsEqual)]
        [InlineData("4", State.Less )]
        [InlineData("6", State.Greater)]
        [InlineData(null, State.Error)]
        [InlineData("-99", State.Less )]
        public void GetCompareState_stringValue_ReturnsResultCorrectly(string inputValue, State expected)
        {
            var myClass = new Quiz(5);
            var actual = myClass.GetCompareState(inputValue);
            Assert.Equal(expected, actual);
        }
    }
}
