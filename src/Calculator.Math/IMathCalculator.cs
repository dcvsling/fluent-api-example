using System;
namespace Calculator.MathExtensions
{
    public interface IMathCalculator<T> where T : struct, IConvertible
    {
        IMathCalculator<R> Compute<R>(Func<T, R> math)
            where R : struct, IConvertible;
        IMathCalculator<R> Compute<T2, R>(Func<T, T2, R> math, ICalculator<T2> calculator2)
            where R : struct, IConvertible
            where T2 : struct, IConvertible;
        IMathCalculator<R> Compute<T2, T3, R>(
            Func<T, T2, T3, R> math, 
            ICalculator<T2> calculator2,
            ICalculator<T3> calculator3)
            where R : struct, IConvertible
            where T2 : struct, IConvertible
            where T3 : struct, IConvertible;

        T Result { get; }
    }
}
