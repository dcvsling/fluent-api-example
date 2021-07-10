using Calculator.Context;
using Xunit;
namespace Calculator.Tests
{
    public class ContextTests 
    {
        [Fact]
        public void test_Context_calculator() {
            var calculator = new CalculatorBuilder()
                .Append(new Add(1))
                .Append(new Divide(3))
                .Build();
            var actual = calculator.Compute(1);
            Assert.NotEqual(0, actual);
            
            Assert.Equal(
                (1 + 1)/3m, 
               actual);
        }
    }

    public class Add : ICalculatorOperator
    {
        public Add(decimal value) {
            Value = value;
        }
        public decimal Value { get; }
        public void Compute(CalculateContext context)
            => context.Value += Value;


    }
    public class Divide : ICalculatorOperator
    {
        public Divide(decimal value) {
            Value = value;
        }
        public decimal Value { get; }
        public void Compute(CalculateContext context)
            => context.Value /= Value;
    }
}
