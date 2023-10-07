using Calculator.Logic;
using FluentAssertions;

namespace Calculator.Tests;

public class EquationValidatorTests
{
    [Fact]
    void IsEquationValid_ShouldReturnFalse_WhenEquationIsNull()
    {
        string? equation = null;
        
        var result = EquationValidator.IsEquationValid(equation);

        result.Should().BeFalse();
    }
    
    [Fact]
    void IsEquationValid_ShouldReturnFalse_WhenEquationIsBlank()
    {
        const string equation = " ";
        
        var result = EquationValidator.IsEquationValid(equation);
        
        result.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("10")]
    [InlineData("10 + 10")]
    [InlineData("10 - 10")]
    [InlineData("10 * 10")]
    [InlineData("10 / 10")]
    [InlineData("10 + 1 -10 * 10 / 2")]
    void IsEquationValid_ShouldReturnTrue_WhenEquationIsValid(string equation)
    {
        var result = EquationValidator.IsEquationValid(equation);
        
        result.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("s")]
    [InlineData("10 + 10s")]
    [InlineData("10 / d - 10")]
    void IsEquationValid_ShouldReturnFalse_WhenEquationIsNotValid(string equation)
    {
        var result = EquationValidator.IsEquationValid(equation);
        
        result.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("10 / 0")]
    [InlineData("10/0")]
    [InlineData("/ 0")]
    [InlineData("/0")]
    void IsEquationValid_ShouldReturnFalse_WhenEquationContainsZeroDivision(string equation)
    {
        var result = EquationValidator.IsEquationValid(equation);
        
        result.Should().BeFalse();
    }
}