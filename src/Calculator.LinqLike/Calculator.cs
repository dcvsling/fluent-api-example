using System;
using System.Collections.Generic;

namespace Calculator.LinqLike
{
    public static partial class Calculator 
    {
        public static ILinqLikeCalculator<T> Create<T>(params T[] values) where T : struct, IConvertible
            => new RootLinqLikeCalculator<T>(values);
        
        public static List<T> ToList<T>(this ILinqLikeCalculator<T> calculator)
            where T : struct, IConvertible
        {
            var result = new List<T>();
            var innerCalculator = calculator.GetCalculator();
            while(innerCalculator.Next()) {
                result.Add(innerCalculator.Current);
            }
            return result;
        }
    }
}
