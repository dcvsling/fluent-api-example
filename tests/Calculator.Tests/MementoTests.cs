using Xunit;
namespace Calculator.Tests
{

    public class MementoTests 
    {
        [Fact]
        public void memento_plus_test() 
        {
            var actual = Calculator.Create(1).Add(2)
                .Plus(Calculator.Create(3).Add(4)).Result;
            Assert.Equal(10, actual);
        }    
        [Fact]
        public void memento_minus_test() 
        {
            var actual = Calculator.Create(1).Add(2)
                .Minus(Calculator.Create(3).Add(4)).Result;
            Assert.Equal(-4, actual);
        }    
    }
}
