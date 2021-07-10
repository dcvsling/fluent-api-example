using System;
using Calculator.Memento;
namespace Calculator
{
    public static class CalculateMementoExtensions
    {
        public static ICalculator<T> Plus<T>(this ICalculator<T> calculator, ICalculator<T> sub)  where T : struct, IConvertible {
            return new MementoPlus<T>(calculator, sub);
        }
        public static ICalculator<T> Minus<T>(this ICalculator<T> calculator, ICalculator<T> sub)  where T : struct, IConvertible {
            return new MementoMinus<T>(calculator, sub);
        }
    }
}
