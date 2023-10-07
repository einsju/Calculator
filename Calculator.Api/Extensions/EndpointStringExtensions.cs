namespace Calculator.Api.Extensions;

public static class EndpointStringExtensions
{
    const string SAFE_DIVISION_VALUE = "%2F";
    
    public static string ToValidEquation(this string? endpointString) =>
        endpointString?.Replace(SAFE_DIVISION_VALUE, "/") ?? string.Empty;
}