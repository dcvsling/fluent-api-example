using System;
namespace Calculator
{
  public static class Calculator 
  {
    public static ICalculator<T> Create<T>(T initNumber = default(T)) where T : struct, IConvertible 
      => new DefaultCalculator<T>(initNumber);
  }

}
