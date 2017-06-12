using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, -2, -3)]
        public void Add_TwoIntegers_ReturnsExpectedResult(int x, int y, int expectedResult)
        {
            var actual = Calculator.Add(x, y);

            Assert.Equal(expectedResult, actual);
        }
    }
}
