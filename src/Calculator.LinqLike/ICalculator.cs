using System;

namespace Calculator.LinqLike
{
    public interface ICalculator<T> where T : struct, IConvertible {
        T Result { get; }
    }
}
