using System;

namespace Calculator.MathExtensions
{
    internal class DefualtMathCalculator<T> : IMathCalculator<T> where T : struct, IConvertible {
        private readonly Func<T> _last;

        public DefualtMathCalculator(Func<T> last) {
            _last = last;
        }


        public IMathCalculator<R> Compute<R>(Func<T, R> math) 
            where R : struct, IConvertible
            => new DefualtMathCalculator<R>(() => math(_last()));
        
        public IMathCalculator<R> Compute<T2, R>(Func<T, T2, R> math, ICalculator<T2> calculator2) 
            where R : struct, IConvertible
            where T2 : struct, IConvertible
            => new DefualtMathCalculator<R>(() => math(_last(), calculator2.Result));

        public IMathCalculator<R> Compute<T2, T3, R>(
            Func<T, T2, T3, R> math, 
            ICalculator<T2> calculator2,
            ICalculator<T3> calculator3)
            where R : struct, IConvertible
            where T2 : struct, IConvertible
            where T3 : struct, IConvertible
            => new DefualtMathCalculator<R>(() => math(_last(), calculator2.Result, calculator3.Result));
            
        public T Result => _last();
    }
}
