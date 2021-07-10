using System;

namespace Calculator.RxLike
{
    public static partial class RxLikeCalculator 
    {
        public static ICalculator<T> Create<T>(Action<IRxLikeCalculator<T>> config) where T : struct, IConvertible
        {
            var result = new RootRxLikeCalculator<T>();
            config(result);
            return result;
        }
    }
    
    internal class RootRxLikeCalculator<T> : ICalculator<T>, IRxLikeCalculator<T> where T : struct, IConvertible {
        private Action<T> _entry = _ => { };
        public RootRxLikeCalculator() {
        }

        public void Dispose() { 
            _entry = _ => throw new ObjectDisposedException(nameof(RootRxLikeCalculator<T>)); 
        }

        public void Next(T value)
            => _entry?.Invoke(value);

        public IDisposable Then(ICalculator<T> calculator)
        {
            _entry = t => calculator.Next(t);
            return this;
        } 
    }

    internal class RootCalcuator<T> : ICalculator<T> where T : struct, IConvertible
    {
        private readonly ICalculator<T> _calculator;

        public RootCalcuator(ICalculator<T> calculator) {
            _calculator = calculator;
        }

        public void Dispose()
        {
            _calculator.Dispose();
        }

        public void Next(T value) {
            _calculator.Next(value);
        }
    }
}
