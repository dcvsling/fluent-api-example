using System;

namespace Calculator.LinqLike
{
    public static partial class LinqLikeCalculator {
        public static ILinqLikeCalculator<R> Compute<T, R>(this ILinqLikeCalculator<T> calculator, Func<T, R> func)
            where T : struct, IConvertible
            where R : struct, IConvertible
            => new ComputeLinqLikeCalculator<T, R>(calculator.GetCalculator(), func);
    }

    internal class ComputeLinqLikeCalculator<T, R> : ILinqLikeCalculator<R>
        where T : struct, IConvertible
        where R : struct, IConvertible
    {
        private readonly ICalculator<T> _last;
        private readonly Func<T, R> _func;
        public ComputeLinqLikeCalculator(ICalculator<T> last, Func<T, R> func)
        {
            _last = last;
            _func = func;
        }
        public ICalculator<R> GetCalculator()
            => new ComputeCalculator<T, R>(_last, _func);
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

        public R Result => _func(_last.Result);
    }
    
}
