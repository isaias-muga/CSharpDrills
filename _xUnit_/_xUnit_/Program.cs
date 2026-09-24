using Xunit;

namespace Pruebas
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
    }

    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsSum()
        {
            var calc = new Calculator();
            // Arrange
            int num1 = 2;
            int num2 = 3;
            // Act
            int result = calc.Add(num1, num2);
            // Assert
            Assert.Equal(5, result);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}