using LibraryManagementSystem.Services.BookService;
using LibraryManagementSystem.Services.BorrowService;
using LibraryManagementSystem.Services.MainApplication;
using LibraryManagementSystem.Services.MemberService;
using LibraryManagementSystem.Services.ReportService;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IBookService, BookService>();
services.AddSingleton<IBorrowService, BorrowService>();
services.AddSingleton<IMemberService, MemberService>();
services.AddSingleton<IReportService, ReportService>();


services.AddSingleton<ILmsApp, LmsApp>();

using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<ILmsApp>();

app.Run();


