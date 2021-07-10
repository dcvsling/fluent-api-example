using System;

namespace Calculator.Memento
{
    internal class MementoMinus<T> : MementoBase<T> where T : struct, IConvertible {
        public MementoMinus(ICalculator<T> last, ICalculator<T> current) : base(last, current) { }

        public override T Result => Calculator.Create(Last.Result).Subtract(Current.Result).Result;
    }
}
