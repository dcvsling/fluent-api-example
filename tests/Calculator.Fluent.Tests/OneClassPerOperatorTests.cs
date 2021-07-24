using Calculator.LinqLike;
using Xunit;
namespace Calculator.Tests
{
    using OneClassPerOperator;
    public class OneClassPerOperatorTests 
    {
        [Fact]
        public void test_OneClassPerOperator_calculator() {
            var actual = Calculator.Create(1m)
                .Add(1)
                .Devide(3)
                .Value;

            Assert.NotEqual(0, actual);
            
            Assert.Equal(
                (1 + 1)/3m, 
               actual);
        }
    }
}
