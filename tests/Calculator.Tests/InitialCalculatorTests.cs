using System;
using Xunit;

namespace Calculator.Tests
{
    public class InitialCalculatorTests
    {
        [Fact]
        public void init_by_default()
            => Assert.Equal(0, Calculator.Create<int>().Result);

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(5.3)]
        public void init_by_custom_number(int initNumber)
            => Assert.Equal(initNumber, Calculator.Create(initNumber).Result);
    }
}
