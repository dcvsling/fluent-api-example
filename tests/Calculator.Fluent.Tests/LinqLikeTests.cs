using Calculator.LinqLike;
using Xunit;
namespace Calculator.Tests
{
    public class LinqLikeTests 
    {
        [Fact]
        public void test_LinqLike_calculator() {
            var actual = LinqLikeCalculator.Create(() => 1m)
                    .Compute(x => x + 1)
                    .Compute(x => x / 3)
                    .GetCalculator()
                    .Result;

            Assert.NotEqual(0, actual);
            
            Assert.Equal(
                (1 + 1)/3m, 
               actual);
        }
    }
}
