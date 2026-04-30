using LibraryManagementSystem;
using LibraryManagementSystem.Learnings.ExplicitImplementation;
using LibraryManagementSystem.MainApplication;
using LibraryManagementSystem.Repository.BookRepository;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Services.BookService;
using LibraryManagementSystem.Services.BorrowService;
using LibraryManagementSystem.Services.MemberService;
using LibraryManagementSystem.Services.ReportService;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

#region Service Registrations
services.AddSingleton<IBookService, BookService>();
services.AddSingleton<IBorrowService, BorrowService>();
services.AddSingleton<IMemberService, MemberService>();
services.AddSingleton<IReportService, ReportService>();
#endregion

#region Repository Registrations
services.AddSingleton<IBookRepository, BookRepository>();
#endregion


services.AddSingleton<ILmsApp, LmsApp>();

using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<ILmsApp>();

app.Run();


