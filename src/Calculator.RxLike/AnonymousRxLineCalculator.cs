using System;
namespace Calculator.RxLike
{
    public static partial class RxLikeCalculator 
    {
        public static IDisposable Then<T>(this IRxLikeCalculator<T> calculator, Action<T> action) where T : struct, IConvertible
            => calculator.Then(new AnonymousCalculator<T>(action));
    }

    internal class AnonymousCalculator<T> : ICalculator<T> where T : struct, IConvertible
    {
        private Action<T> _action;
        public AnonymousCalculator(Action<T> action) {
            _action = action;
        }
        public void Dispose()
        {
            _action = _ => {};
            GC.SuppressFinalize(this);
        }

        public void Next(T value)
            => _action(value);
    }
}
