using System;

namespace Calculator.Context
{

    public class CalculateContext
    {
        public CalculateContext(decimal value) {
            Value = value;
        }

        public decimal Value { get; set; }
    }
}
