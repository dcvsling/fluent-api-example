using System;
using Calculator.MathExtensions;
using Xunit;
namespace Calculator.Tests
{
    public class MathExtensionsTests 
    {
        [Fact]
        public void test_no_arg_method() {
            Assert.Equal(2, Calculator.Create(1).UseMath().Compute(a => a + 1).Result);  
        }

        [Fact]
        public void test_one_arg_method() {
            Assert.Equal(3, Calculator.Create(1).UseMath().Compute((a, b)=> a + b, Calculator.Create(2)).Result);  
        }

        [Fact]
        public void test_two_arg_method() {
            Assert.Equal(7, Calculator.Create(1).UseMath()
                .Compute((a, b, c) => a + b * c, 
                    Calculator.Create(2), 
                    Calculator.Create(3))
                .Result);  
        }

        [Fact]
        public void test_abs_method() {
            Assert.Equal(1m, Calculator.Create(-1m).UseMath()
                .Compute(Math.Abs)
                .Result);  
        }
    }
}
