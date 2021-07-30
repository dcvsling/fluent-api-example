using System;

namespace Calculator.LinqLike
{
    public interface ICalculator<T> where T : struct, IConvertible {
        bool Next();
        T Current { get; }
    }
}
