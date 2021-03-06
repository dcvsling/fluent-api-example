using System;

namespace Calculator.LinqLike
{
    public static partial class Calculator {
        public static ILinqLikeCalculator<R> Compute<T, R>(this ILinqLikeCalculator<T> calculator, Func<T, R> func)
            where T : struct, IConvertible
            where R : struct, IConvertible
            => new ComputeLinqLikeCalculator<T, R>(calculator, func);
    }

    internal class ComputeLinqLikeCalculator<T, R> : ILinqLikeCalculator<R>
        where T : struct, IConvertible
        where R : struct, IConvertible
    {
        private readonly ILinqLikeCalculator<T> _last;
        private readonly Func<T, R> _func;
        public ComputeLinqLikeCalculator(ILinqLikeCalculator<T> last, Func<T, R> func)
        {
            _last = last;
            _func = func;
        }
        public ICalculator<R> GetCalculator()
            => new ComputeCalculator<T, R>(_last.GetCalculator(), _func);
    }
    
    internal class ComputeCalculator<T, R> : ICalculator<R> 
        where T : struct, IConvertible
        where R : struct, IConvertible
    {
        private readonly ICalculator<T> _last;
        private readonly Func<T, R> _func;

        public ComputeCalculator(ICalculator<T> last, Func<T, R> func) {
            _last = last;
            _func = func;
        }

        public R Current => _func(_last.Current);

        public bool Next()
            => _last.Next();
    }
}
