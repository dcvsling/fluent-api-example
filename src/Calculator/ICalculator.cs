using System;

namespace Calculator
{
    public interface ICalculator<T> where T : struct, IConvertible
    {
        ICalculator<T> Add(T number);
        ICalculator<T> Subtract(T number);
        ICalculator<T> Multiply(T number);
        ICalculator<T> Divide(T number);
        T Result { get; }
    }

}
