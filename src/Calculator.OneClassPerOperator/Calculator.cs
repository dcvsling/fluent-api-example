using System;

namespace Calculator.OneClassPerOperator
{
    public static class Calculator 
    {
        public static ICalculator<T> Create<T>(T initNumber = default(T)) where T : struct, IConvertible 
        => new RootCalculator<T>(initNumber);
    }

    internal class RootCalculator<T> : ICalculator<T> where T : struct, IConvertible
    {
        public RootCalculator(T value) {
            Value = value;
        }
        public T Value { get; }
    }
}
