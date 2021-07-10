using System;

namespace Calculator.Memento
{
    internal class MementoPlus<T> : MementoBase<T>  where T : struct, IConvertible {
        public MementoPlus(ICalculator<T> last, ICalculator<T> current) : base(last, current) { }

        public override T Result => Calculator.Create(Last.Result).Add(Current.Result).Result;
    }
}
