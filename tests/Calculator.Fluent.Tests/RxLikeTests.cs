using Calculator.RxLike;
using Xunit;
namespace Calculator.Tests
{
    public class RxLikeTests {
        [Fact]
        public void test_RxLike_calculator() {
            var calculator = RxLikeCalculator.Create<decimal>(cal => cal
                    .Compute(x => x + 1)
                    .Compute(x => x / 3m)
                    .Then(CheckValue));
            calculator.Next(1);

            void CheckValue(decimal actual) {
                Assert.NotEqual(0, actual);
            
                Assert.Equal((1 + 1)/3m, actual);
            }
        }
    }
}
