using System;
using System.Linq;
using Xunit;
namespace Calculator.LinqLike.Tests
{
    public class LinqLikeTests 
    {
        [Fact]
        public void test_LinqLike_calculator() {
            var seed = Enumerable.Range(1, 3).ToArray(); // create [1, 2, 3]
            var actuals = Calculator.Create(seed)
                    .Compute(x => x + 1)
                    .Compute(x => x / 3m)
                    .ToList();

            var expects = seed.Select(numb =>  (numb + 1)/3m).ToList();
            Assert.Equal(expects, actuals);
        }

        [Fact]
        public void test_each_compute_is_independent_when_has_branch() {
            var seed = Enumerable.Range(1, 3).ToArray(); // create [1, 2, 3]
            
            var calculator = Calculator.Create(seed).Compute(x => x + 1);
            var actual = calculator.Compute(x => calculator.Compute(y => x + y).ToList()[0]).ToList();

            var linq = seed.Select(x => x + 1);
            var expect = linq.Select(x => linq.Select(y => x + y).ToList()[0]).ToList();

            Assert.Equal(expect, actual);
        }
    }
}
