using System;
using Calculator.MathExtensions;
namespace Calculator
{
    public static class MathCalculatorExtensions
    {
        public static IMathCalculator<T> UseMath<T>(this ICalculator<T> calculator) where T : struct, IConvertible
            => new DefualtMathCalculator<T>(() => calculator.Result);
    }
}
