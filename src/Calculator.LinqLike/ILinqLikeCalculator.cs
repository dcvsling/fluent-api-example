using System;

namespace Calculator.LinqLike
{
    public interface ILinqLikeCalculator<T> where T : struct, IConvertible {
        ICalculator<T> GetCalculator();
    }
}
