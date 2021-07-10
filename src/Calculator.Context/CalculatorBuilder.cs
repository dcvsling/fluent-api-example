using System.Collections.Generic;

namespace Calculator.Context
{
    public class CalculatorBuilder {
        private readonly List<ICalculatorOperator> _operators = new List<ICalculatorOperator>();
        public CalculatorBuilder Append(ICalculatorOperator @operator) {
            _operators.Add(@operator);
            return this;
        }

        public ICalculator Build()
            => new DefaultCalculator(_operators);
    }
}
