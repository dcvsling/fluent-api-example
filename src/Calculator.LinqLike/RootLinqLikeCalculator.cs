using System;

namespace Calculator.LinqLike
{
    internal class RootLinqLikeCalculator<T> : ILinqLikeCalculator<T> where T : struct, IConvertible {
        
        private readonly T[] _values;

        public RootLinqLikeCalculator(T[] values) {
            _values = values;
        }

        public ICalculator<T> GetCalculator()
            => new RootCalculator<T>(_values);
    }

    internal class RootCalculator<T> : ICalculator<T> where T : struct, IConvertible
    {
        private readonly T[] _values;
        private int _index = -1;
        public RootCalculator(T[] values) {
            _values = values;
        }
        public T Current => _values[_index];

        public bool Next()
            => ++_index <= _values.Length - 1;
    }
}
