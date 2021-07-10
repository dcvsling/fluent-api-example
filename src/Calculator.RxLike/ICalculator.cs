using System;

namespace Calculator.RxLike
{
    public interface ICalculator<T> : IDisposable where T : struct, IConvertible {
        void Next(T value);
    }
}
