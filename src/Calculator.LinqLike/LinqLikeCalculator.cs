using System;
namespace Calculator.LinqLike
{
    public static partial class LinqLikeCalculator 
    {
        public static ILinqLikeCalculator<T> Create<T>(Func<T> getter) where T : struct, IConvertible
            => new RootLinqLikeCalculator<T>(getter);
    }
}
