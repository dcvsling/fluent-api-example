using System.Collections.Generic;
using System.Linq;

namespace Calculator.Context
{
    internal class DefaultCalculator : ICalculator 
    {
        private readonly IEnumerable<ICalculatorOperator> _operators;

        public DefaultCalculator(IEnumerable<ICalculatorOperator> operators) {
            _operators = operators;
        }
        public decimal Compute(decimal value)
            => _operators.Aggregate(new CalculateContext(value), Reduce).Value;

        private static CalculateContext Reduce(CalculateContext context, ICalculatorOperator @operator)
        {
            @operator.Compute(context);
            return context;
        }
    }
}
