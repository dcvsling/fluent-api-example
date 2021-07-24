using System;

namespace Calculator.OneClassPerOperator
{
    internal class RootCalculator<T> : ICalculator<T> where T : struct, IConvertible
    {
        public RootCalculator(T value) {
            Value = value;
        }
        public T Value { get; }
    }
}
