using System;

namespace Calculator.OneClassPerOperator
{
    public interface ICalculator<T> where T : struct, IConvertible {
        T Value { get; }
    }
}
