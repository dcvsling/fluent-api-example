using System;
namespace Calculator
{
    internal class DefaultCalculator<T> : ICalculator<T> where T : struct, IConvertible
  {
    private T _value;
    public DefaultCalculator(T initValue = default(T)) 
    {
      _value = initValue;
    }
    public ICalculator<T> Add(T number) 
    {
      _value = (T)Convert.ChangeType(Convert.ToDecimal(_value) + Convert.ToDecimal(number), typeof(T));
      return this;
    }
    public ICalculator<T> Subtract(T number) 
    {
      _value = (T)Convert.ChangeType(Convert.ToDecimal(_value) - Convert.ToDecimal(number), typeof(T));
      return this;
    }
    public ICalculator<T> Multiply(T number) 
    {
      _value = (T)Convert.ChangeType(Convert.ToDecimal(_value) * Convert.ToDecimal(number), typeof(T));
      return this;
    }
    public ICalculator<T> Divide(T number) 
    {
      _value = (T)Convert.ChangeType(Convert.ToDecimal(_value) / Convert.ToDecimal(number), typeof(T));
      return this;
    }
    public T Result => _value;
  }

}
