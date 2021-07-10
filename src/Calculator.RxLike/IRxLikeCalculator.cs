using System;

namespace Calculator.RxLike
{
    public interface IRxLikeCalculator<T> where T : struct, IConvertible {
        IDisposable Then(ICalculator<T> calculator);
    }
}
