using System;

namespace Calculator.Memento
{
    internal abstract class MementoBase<T> : ICalculator<T> where T : struct, IConvertible
    {
        protected ICalculator<T> Last { get; }
        protected ICalculator<T> Current { get; }
        protected MementoBase(ICalculator<T> last, ICalculator<T> current) {
            Last = last;
            Current = current;
        }
        
        public ICalculator<T> Add(T number) {
            Current.Add(number);
            return this;
        }
        public ICalculator<T> Subtract(T number) {
            Current.Subtract(number);
            return this;
        }
        public ICalculator<T> Multiply(T number) {
            Current.Multiply(number);
            return this;
        }
        public ICalculator<T> Divide(T number) {
            Current.Divide(number);
            return this;
        }
        public abstract T Result { get; }
    }
}
