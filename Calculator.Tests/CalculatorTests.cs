using FluentAssertions;
using ApiCalculator = Calculator.Logic.Calculator;

namespace Calculator.Tests;

public class CalculatorTests
{
    [Fact]
    void Calculate_ShouldStartFromZero_WhenEquationDoesNotStartWithOperator()
    {
        const double currentValue = 10.0;
        const string equation = "10 + 10";
        
        var result = ApiCalculator.Calculate(equation, currentValue);

        result.Should().Be(20);
    }
    
    [Theory]
    [InlineData("+10 + 10", 10, 30)]
    [InlineData("-10 + 10", 10, 10)]
    [InlineData("*10 + 10", 10, 110)]
    [InlineData("/10 + 10", 10, 11)]
    void Calculate_ShouldAddToCurrentValue_WhenEquationStartsWithOperator(string equation, double currentValue, double expectedResult)
    {
        var result = ApiCalculator.Calculate(equation, currentValue);
        
        result.Should().Be(expectedResult);
    }
}