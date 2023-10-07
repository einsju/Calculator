using System.Data;

namespace Calculator.Logic;

public static class Calculator
{
    public static double Calculate(string equation, double currentValue = 0.0)
    {
        equation = EquationStartsWithOperator(equation) ? $"{currentValue} {equation}" : equation;
        
        var value = Convert.ToDouble(new DataTable().Compute(equation, ""));
        
        return value;
    }
    
    static bool EquationStartsWithOperator(string equation) =>
        equation.StartsWith('+') || equation.StartsWith('-') || equation.StartsWith('*') || equation.StartsWith('/');
}