using System;

namespace Calculator.OneClassPerOperator
{

    public static class CalculatorExtensions 
    {
        public static ICalculator<T> Add<T>(this ICalculator<T> calculator, T numberForAdd) where T : struct, IConvertible
            => new SimpleComputeCalculator<T>(
                calculator, 
                last =>  (T)Convert.ChangeType(Convert.ToDecimal(last) + Convert.ToDecimal(numberForAdd), typeof(T)));
        public static ICalculator<T> Subtract<T>(this ICalculator<T> calculator, T numberForAdd) where T : struct, IConvertible
            => new SimpleComputeCalculator<T>(
                calculator, 
                last =>  (T)Convert.ChangeType(Convert.ToDecimal(last) - Convert.ToDecimal(numberForAdd), typeof(T)));

        public static ICalculator<T> Multiply<T>(this ICalculator<T> calculator, T numberForAdd) where T : struct, IConvertible
            => new SimpleComputeCalculator<T>(
                calculator, 
                last =>  (T)Convert.ChangeType(Convert.ToDecimal(last) * Convert.ToDecimal(numberForAdd), typeof(T)));

        public static ICalculator<T> Devide<T>(this ICalculator<T> calculator, T numberForAdd) where T : struct, IConvertible
            => new SimpleComputeCalculator<T>(
                calculator, 
                last =>  (T)Convert.ChangeType(Convert.ToDecimal(last) / Convert.ToDecimal(numberForAdd), typeof(T)));
    }
    internal class SimpleComputeCalculator<T> : ICalculator<T>
        where T : struct, IConvertible
    {
        private readonly ICalculator<T> _last;
        private readonly Func<T, T> _compute;

        public SimpleComputeCalculator(ICalculator<T> last, Func<T, T> compute) {
            _last = last;
            _compute = compute;
        }
        public T Value => _compute(_last.Value);
    }
}
