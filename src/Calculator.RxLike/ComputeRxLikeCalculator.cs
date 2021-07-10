using System;

namespace Calculator.RxLike
{
    public static partial class RxLikeCalculator {
        public static IRxLikeCalculator<R> Compute<T, R>(this IRxLikeCalculator<T> calculator, Func<T, R> func)
            where T : struct, IConvertible
            where R : struct, IConvertible
            => new ComputeRxLikeCalculator<T, R>(calculator, func);
    }

    internal class ComputeRxLikeCalculator<T, R> : IRxLikeCalculator<R>
        where T : struct, IConvertible
        where R : struct, IConvertible
    {
        private readonly IRxLikeCalculator<T> _last;
        private readonly Func<T, R> _func;
        public ComputeRxLikeCalculator(IRxLikeCalculator<T> last, Func<T, R> func)
        {
            _last = last;
            _func = func;
        }
        public IDisposable Then(ICalculator<R> calculator)
            => _last.Then(new ComputeCalculator<T, R>(calculator, _func));
    }
    
    internal class ComputeCalculator<T, R> : ICalculator<T> 
        where T : struct, IConvertible
        where R : struct, IConvertible
    {
        private readonly ICalculator<R> _last;
        private readonly Func<T, R> _func;

        public ComputeCalculator(ICalculator<R> last, Func<T, R> func) {
            _last = last;
            _func = func;
        }

        public void Dispose()
            => _last.Dispose();

        public void Next(T value) {
            _last.Next(_func(value));
        }
    }
    
}
