using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
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

            [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1.1)]
        [InlineData(int.MaxValue)]
        public void test_calculator_add_number(int number) {
            Assert.Equal(number, Calculator.Create<int>().Add(number).Result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1.1)]
        [InlineData(int.MaxValue)]
        public void test_calculator_substract_number(int number) {
            Assert.Equal(-1 * number, Calculator.Create<int>().Subtract(number).Result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(1.1, 1.1, 1)]
        public void test_default_calculator_multiply_number(int initNumber, int number, int expect) {
            Assert.Equal(expect, Calculator.Create(initNumber).Multiply(number).Result);
        }

        [Theory]
        [InlineData(4,2,2)]
        [InlineData(100, 5, 20)]
      public void test_default_calculator_devide_number(int initNumber, int number, int expect) {
            Assert.Equal(expect, Calculator.Create(initNumber).Divide(number).Result);
        }
    }
}
