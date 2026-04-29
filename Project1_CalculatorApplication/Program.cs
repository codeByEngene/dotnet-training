using System.Transactions;
using CalculatorConsoleApp.Repositories;
using CalculatorConsoleApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;

var services = new ServiceCollection();

services.AddSingleton<ICalculatorService, CalculatorService>();


services.AddSingleton<ICalculationHistoryRepository>(serviceProvider =>
{
    var dataDirectory = Path.Combine( AppContext.BaseDirectory,"Data");
    Directory.CreateDirectory(dataDirectory);

    var filePath = Path.Combine(dataDirectory, "calculation-history.json");
    return new JsonCalculationHistoryRepository(filePath);
});

services.AddSingleton<ICalculatorApp, CalculatorApp>();

using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<ICalculatorApp>();

app.Run();

