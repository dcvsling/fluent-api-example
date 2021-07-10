using System;

namespace Calculator.LinqLike
{
    internal class RootLinqLikeCalculator<T> : ILinqLikeCalculator<T> where T : struct, IConvertible {
        
        private readonly Func<T> _getter;

        public RootLinqLikeCalculator(Func<T> getter) {
            _getter = getter;
        }

        public ICalculator<T> GetCalculator()
            => new RootCalcuator<T>(_getter);
    }

    internal class RootCalcuator<T> : ICalculator<T> where T : struct, IConvertible
    {
        private readonly Func<T> _getter;

        public RootCalcuator(Func<T> getter) {
            _getter = getter;
        }
        public T Result => _getter();
    }
}
