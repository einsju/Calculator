using System.Web;
using Calculator.Api.Extensions;
using Calculator.Logic;
using ApiCalculator = Calculator.Logic.Calculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var calculatedValue = 0.0;

app.MapGet("/{equation}", (string? equation) =>
{
    equation = equation.ToValidEquation();
    
    if (!EquationValidator.IsEquationValid(equation))
        return Results.BadRequest("Please provide a valid equation...");

    var currentValue = calculatedValue;
    calculatedValue = ApiCalculator.Calculate(equation!, currentValue);
    
    return Results.Ok(calculatedValue);
})
.WithName("Calculate")
.WithOpenApi();

app.Run();
