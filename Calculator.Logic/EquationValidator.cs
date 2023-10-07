using System.Text.RegularExpressions;

namespace Calculator.Logic;

public static partial class EquationValidator
{
    static readonly Regex ValidExpressionRegex = ValidEquationRegex();

    [GeneratedRegex(@"^([-+/*()]|\d)+$")]
    private static partial Regex ValidEquationRegex();

    public static bool IsEquationValid(string? equation)
    {
        if (string.IsNullOrWhiteSpace(equation)) return false;

        equation = equation.Replace(" ", string.Empty);
        
        return !IsContainingZeroDivision(equation) && ValidExpressionRegex.IsMatch(equation);
    }
    
    static bool IsContainingZeroDivision(string equation) => equation.Contains("/0");
}