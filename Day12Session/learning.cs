//Run Static Functions in Parallel with async/await


// // ── Shared sync function (unmodified) ─────────────────────
// static int HeavyComputation(int input)
// {
//     Thread.Sleep(500); // 0.5s per call to keep demo fast
//     return input * 2;
// }

// // ── Option 1: Sequential ──────────────────────────────────
// //Runs iterations ONE BY ONE. Safe, predictable, but slow.
// static async Task RunSequentiallyAsync()
// {
//     // Task.Run offloads the sync call to a thread pool thread.
//     // await suspends here without blocking the calling thread.

//     // Next iteration only starts after this one completes.

//     for (int i = 0; i < 4; i++)
//     {
//         int result = await Task.Run(() => HeavyComputation(i));
//         Console.WriteLine($"  [Seq]      i={i} → {result}");
//     }
// }

// // ── Option 2: All parallel ────────────────────────────────
// //// Starts ALL iterations simultaneously. Total time ≈ single iteration.
// static async Task RunParallelAsync()
// {
//     // .Select creates tasks but does NOT await them yet.
//     // .ToList() forces all tasks to START immediately.
//     var tasks = Enumerable.Range(0, 4)
//         .Select(i => Task.Run(() => HeavyComputation(i)))
//         .ToList(); // .ToList() starts all tasks NOW

//     // WhenAll waits until EVERY task finishes.
//     // Results are in original order, not completion order.
//     int[] results = await Task.WhenAll(tasks);
//     foreach (var r in results)
//         Console.WriteLine($"  [Parallel] result={r}");
// }

// // // ── Option 3: Throttled with SemaphoreSlim ────────────────
// // Runs up to 4 iterations concurrently. Safe for large loops.
// static async Task RunWithThrottleAsync()
// {
//     // Acts as a gate — only 4 tasks can run at the same time.
//     var semaphore = new SemaphoreSlim(4); // 4 at a time
//     var tasks = Enumerable.Range(0, 4).Select(async i =>
//     {
//         // Async wait for a free slot (non-blocking).
//         await semaphore.WaitAsync();
//         try   { 
//              // Slot acquired — run the sync function.
//             return await Task.Run(() => HeavyComputation(i)); 
//         }
//         finally { 
//             // Always release — even if an exception is thrown.
//             // Omitting this causes a deadlock.
//             semaphore.Release(); 
//         } // always release
//     });
//     int[] results = await Task.WhenAll(tasks);
//     Console.WriteLine($"  [Throttle] done. Count={results.Length}");
// }

// // // ── Option 4: Parallel.ForEachAsync (.NET 6+) ─────────────
// // // .NET 6+ only. Cleanest API — built-in throttle + cancellation.
// static async Task RunWithForEachAsync()
// {
//     await Parallel.ForEachAsync(
//         Enumerable.Range(0, 4),
//         new ParallelOptions { MaxDegreeOfParallelism = 4 },
//         // ct is provided per-iteration by ForEachAsync.
//         async (i, ct) =>
//         {
//             int result = await Task.Run(() => HeavyComputation(i), ct);
//             Console.WriteLine($"  [ForEach]  i={i} → {result}");
//         });
// }

// // // ── Option 5: With cancellation ───────────────────────────
// // // Cancellable parallel loop — aborts after a timeout.
// static async Task RunWithCancellationAsync(CancellationToken ct)
// {
//      // ct skips tasks not yet started when cancelled.
//     // Running tasks finish naturally (sync fn can't be interrupted).
//     var tasks = Enumerable.Range(0, 6)
//         .Select(i => Task.Run(() => HeavyComputation(i), ct));
//     try
//     {
//         await Task.WhenAll(tasks);
//         Console.WriteLine("  [Cancel]  completed successfully.");
//     }
//     catch (OperationCanceledException)
//     {
//         Console.WriteLine("  [Cancel]  cancelled before completion.");
//     }
// }

// // // ── Run all options ────────────────────────────────────────
// var sw = System.Diagnostics.Stopwatch.StartNew();

// Console.WriteLine("Option 1 — Sequential:");
// await RunSequentiallyAsync();
// Console.WriteLine($"  ⏱ {sw.ElapsedMilliseconds}ms"); sw.Restart();

// Console.WriteLine("Option 2 — Parallel:");
// await RunParallelAsync();
// Console.WriteLine($"  ⏱ {sw.ElapsedMilliseconds}ms"); sw.Restart();

// Console.WriteLine("Option 3 — Throttled:");
// await RunWithThrottleAsync();
// Console.WriteLine($"  ⏱ {sw.ElapsedMilliseconds}ms"); sw.Restart();

// Console.WriteLine("Option 4 — ForEachAsync:");
// await RunWithForEachAsync();
// Console.WriteLine($"  ⏱ {sw.ElapsedMilliseconds}ms"); sw.Restart();

// Console.WriteLine("Option 5 — Cancellation (timeout=1s):");
// var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
// await RunWithCancellationAsync(cts.Token);
// Console.WriteLine($"  ⏱ {sw.ElapsedMilliseconds}ms");
// sw.Stop();


/*
using System.Diagnostics;

static int HeavyComputation(int input)
{
    Thread.Sleep(500); // 0.5s per call
    return input * 2;
}


static async Task RunSequentiallyAsync()
{
    for (int i = 0; i < 12; i++)
    {
        int result = await Task.Run(() => HeavyComputation(i));
        Console.WriteLine($"  [Seq]      i={i} → {result}");
    }
}


static async Task RunParallelAsync()
{
    var tasks = Enumerable.Range(0, 12)
        .Select(i => Task.Run(() => HeavyComputation(i)))
        .ToList();

    int[] results = await Task.WhenAll(tasks);
    foreach (var r in results)
        Console.WriteLine($"  [Parallel] result={r}");
}


static async Task RunWithThrottleAsync()
{
    var semaphore = new SemaphoreSlim(4); // max 4 concurrent

    var tasks = Enumerable.Range(0, 12).Select(async i =>
    {
        await semaphore.WaitAsync(); // wait for a free slot
        try
        {
            return await Task.Run(() => HeavyComputation(i));
        }
        finally
        {
            semaphore.Release(); // ALWAYS release, even on exception
        }
    });

    int[] results = await Task.WhenAll(tasks);
    Console.WriteLine($"  [Throttle] done. Count={results.Length}");
}


static async Task RunWithForEachAsync()
{
    await Parallel.ForEachAsync(
        Enumerable.Range(0, 12),
        new ParallelOptions { MaxDegreeOfParallelism = 4 },
        async (i, ct) =>
        {
            int result = await Task.Run(() => HeavyComputation(i), ct);
            Console.WriteLine($"  [ForEach]  i={i} → {result}");
        });
}


static async Task RunWithCancellationAsync(CancellationToken ct)
{
    var tasks = Enumerable.Range(0, 12)
        .Select(i => Task.Run(() => HeavyComputation(i), ct));
    try
    {
        await Task.WhenAll(tasks);
        Console.WriteLine("  [Cancel]  completed successfully.");
    }
    catch (OperationCanceledException)
    {
        // Fires because 600ms < 500ms × all items
        Console.WriteLine("  [Cancel]  cancelled — timeout hit before all finished.");
    }
}

var sw = Stopwatch.StartNew();

Console.WriteLine("Option 1 — Sequential (no parallelism):");
Console.WriteLine("  Expected: ~6000ms (12 × 500ms one by one)");
await RunSequentiallyAsync();
Console.WriteLine($"  ⏱ Actual: {sw.ElapsedMilliseconds}ms\n");
sw.Restart();

Console.WriteLine("Option 2 — Parallel, no limit (dangerous at scale):");
Console.WriteLine("  Expected: ~500ms (all 12 at once, no throttle)");
await RunParallelAsync();
Console.WriteLine($"  ⏱ Actual: {sw.ElapsedMilliseconds}ms\n");
sw.Restart();

Console.WriteLine("Option 3 — Throttled, SemaphoreSlim(4) (verbose):");
Console.WriteLine("  Expected: ~1500ms (3 batches of 4 × 500ms)");
await RunWithThrottleAsync();
Console.WriteLine($"  ⏱ Actual: {sw.ElapsedMilliseconds}ms\n");
sw.Restart();

Console.WriteLine("Option 4 — ForEachAsync, MaxDegree=4 ✅ RECOMMENDED:");
Console.WriteLine("  Expected: ~1500ms (same as Option 3, less code)");
await RunWithForEachAsync();
Console.WriteLine($"  ⏱ Actual: {sw.ElapsedMilliseconds}ms\n");
sw.Restart();

Console.WriteLine("Option 5 — Cancellation, timeout=600ms:");
Console.WriteLine("  Expected: cancelled (600ms < time needed for all 12)");
var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(600));
await RunWithCancellationAsync(cts.Token);
Console.WriteLine($"  ⏱ Actual: {sw.ElapsedMilliseconds}ms");
sw.Stop();
*/



/*
small fixed tasks = Task.WhenAll
looping over data = ForEachAsync 
need cancellation = ForEachAsync with CancellationToken in ParallelOptions
pre-.NET 6 = SemaphoreSlim 
*/








//*************************************************** Dependency Injection ******************************************************//
/*
Dependency Injection (DI) is a fancy term for a simple idea:

"Instead of a class creating the tools it needs, the tools are handed to the class 
from the outside."

Dependency: A "tool" that a class needs to do its job (e.g., a Database, an Email service, a Logger).
Injection: The act of "handing" or "passing" that tool into the class.


//Analogy:
Imagine a Chef. To do his job, the Chef needs a Knife.

The WRONG Way (Tight Coupling): The Chef is born with a knife permanently welded to his hand.

The Problem: If the knife gets dull, the Chef is useless. If the Chef needs a bread knife instead of a steak knife, he can't change it. He is "tightly coupled" to that specific knife.
The DI Way (Loose Coupling): The Chef has an empty hand. When he enters the kitchen, a Kitchen Assistant hands him a knife.

The Benefit: If the knife is dull, the assistant gives him a sharp one. If he needs to cut bread, the assistant hands him a serrated knife. The Chef doesn't care where the knife came from; he just knows how to use any knife handed to him.
In this analogy:

The Chef = The Class.
The Knife = The Dependency.
The Assistant = The Dependency Injector (The "Magic" that provides the tool).
*/
//Bad Practice Example
/*
public class EmailService {
    public void Send(string msg) => Console.WriteLine("Sending Email: " + msg);
}

public class OrderProcessor {
    private EmailService _emailService = new EmailService();

    public void ProcessOrder() {
        Console.WriteLine("Order processed.");
        _emailService.Send("Order successful!");
    }
}
//In this example, the OrderProcessor is tightly coupled to the EmailService. 
//If we want to change how notifications are sent (e.g., switch to SMS), 
//we would have to modify the OrderProcessor class, 
//which is not ideal.
*/


//Updated Code
//Now, we introduce an Interface (The "Knife" shape) and Inject it.
// 1. Define the "Shape" of the tool (The Interface)
/*
public interface IMessageService {
    void Send(string msg);
}

// 2. Create different tools that fit that shape
public class EmailService : IMessageService {
    public void Send(string msg) => Console.WriteLine("Sending Email: " + msg);
}

public class SmsService : IMessageService {
    public void Send(string msg) => Console.WriteLine("Sending SMS: " + msg);
}

// 3. The Class now asks for the tool in its constructor
public class OrderProcessor {
    private readonly IMessageService _messageService;

    // INJECTION: We don't say "new EmailService()". 
    // We say "Give me anything that fits the IMessageService shape."
    public OrderProcessor(IMessageService messageService) {
        _messageService = messageService;
    }

    public void ProcessOrder() {
        Console.WriteLine("Order processed.");
        _messageService.Send("Order successful!");
    }
}

// --- Running the code ---
class Program {
    static void Main() {
        // We decide HERE which tool to inject
        IMessageService myTool = new SmsService(); // Want SMS? Use SmsService.
        
        // Hand the tool to the processor (Injection)
        var processor = new OrderProcessor(myTool); 
        
        processor.ProcessOrder();
    }
}
*/




//Constructor Injection
//The dependency is provided at the moment the object is created. 
//This is the most secure method because it ensures the class is never in an "incomplete" state (it cannot exist without its required tools).
/*
using System;

namespace DI_Examples
{
    // 1. THE INTERFACE (The Contract)
    // By defining an interface, the 'NotificationManager' doesn't need to know 
    // exactly WHICH service it is using, just that the service has a 'SendMessage' method.
    public interface IMessageService {
        void SendMessage(string message);
    }

    // 2. CONCRETE IMPLEMENTATION A
    public class EmailService : IMessageService {
        public void SendMessage(string message) => Console.WriteLine($"[Email] Sending: {message}");
    }

    // 2. CONCRETE IMPLEMENTATION B
    public class SmsService : IMessageService {
        public void SendMessage(string message) => Console.WriteLine($"[SMS] Sending: {message}");
    }

    // 3. THE CLIENT CLASS
    public class NotificationManager {
        // 'readonly' ensures the dependency cannot be accidentally changed after the object is created
        private readonly IMessageService _messageService;

        // CONSTRUCTOR INJECTION:
        // Instead of saying 'new EmailService()', we ask for 'IMessageService' in the constructor.
        // This "inverts" the control: the manager no longer decides WHICH service to use; 
        // whoever creates the manager decides.
        public NotificationManager(IMessageService messageService) {
            _messageService = messageService;
        }

        public void Notify(string message) {
            // The manager simply uses the tool it was given
            _messageService.SendMessage(message);
        }
    }

    class Program {
        static void Main() {
            // Scenario A: We want to use Email
            IMessageService emailTool = new EmailService(); 
            NotificationManager emailManager = new NotificationManager(emailTool); // Injecting Email
            emailManager.Notify("Hello via Email!");

            // Scenario B: We want to use SMS
            IMessageService smsTool = new SmsService();
            NotificationManager smsManager = new NotificationManager(smsTool); // Injecting SMS
            smsManager.Notify("Hello via SMS!");
        }
    }
}
*/


//Property Injection
//The dependency is assigned to a public property. 
//This is ideal for optional dependencies or settings that might need to be changed while the program is already running.
/*
using System;

namespace DI_Examples
{
    // 1. THE INTERFACE
    public interface ILogger {
        void Log(string message);
    }

    // 2. IMPLEMENTATIONS
    public class ConsoleLogger : ILogger {
        public void Log(string message) => Console.WriteLine($"Log to Console: {message}");
    }

    public class FileLogger : ILogger {
        public void Log(string message) => Console.WriteLine($"Log to File: {message}");
    }

    // 3. THE CLIENT CLASS
    public class BusinessProcessor {
        // PROPERTY INJECTION:
        // The dependency is a public property. This means it can be set 
        // AFTER the object is instantiated.
        public ILogger Logger { get; set; }
        public string HelloString { get; set; }

        public void ProcessPayment() {
            Console.WriteLine("Processing payment...");

            // Because Property Injection is optional, we must check if the 
            // logger was actually provided before using it (using the ? operator).
            Logger?.Log("Payment processed successfully.");
        }
    }

    class Program {
        static void Main() {
            var processor = new BusinessProcessor();

            // 1. Test without a logger (It should still work, just not log anything)
            Console.WriteLine("Step 1: No logger assigned.");
            processor.ProcessPayment(); 

            // 2. Inject ConsoleLogger via the property
            Console.WriteLine("\nStep 2: Injecting ConsoleLogger.");
            processor.Logger = new ConsoleLogger();
            processor.ProcessPayment();

            // 3. Switch to FileLogger at runtime without creating a new processor
            Console.WriteLine("\nStep 3: Changing to FileLogger at runtime.");
            processor.Logger = new FileLogger();
            processor.ProcessPayment();
        }
    }
}
*/


//Method Injection
//The dependency is passed as a parameter directly into the method that needs it. 
//This is used when a class doesn't need the dependency for its entire life, but only for one specific task.

/*
using System;
using System.Threading.Tasks;

public interface IFileService {
    void Save(string fileName, string content);
}

public class DiskFileService : IFileService {
    public void Save(string fileName, string content) => Console.WriteLine($"Saved to Disk: {fileName}");
}

public class CloudFileService : IFileService {
    public void Save(string fileName, string content) => Console.WriteLine($"Saved to Cloud: {fileName}");
}

public class ReportGenerator {
    // Notice: There is NO constructor injection here. 
    // The class doesn't "own" a file service.

    public string CreateReportContent() {
        return "This is the report data: 100 units sold.";
    }

    // METHOD INJECTION: The service is passed as a parameter directly to the method
    public void ExportReport(string content, IFileService fileService) {
        fileService.Save("Report.txt", content);
    }
}

class Program {
    static void Main() {
        var generator = new ReportGenerator();
        string report = generator.CreateReportContent();

        // We can choose WHICH service to inject at the moment we call the method!
        
        // 1. Inject the Disk Service
        generator.ExportReport(report, new DiskFileService());

        // 2. Inject the Cloud Service
        generator.ExportReport(report, new CloudFileService());
    }
}
*/

/*
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("*********************************************************");
Console.WriteLine("*********************************************************");
Console.WriteLine("******************  Practice Session  *******************");
Console.WriteLine("*********************************************************");
Console.WriteLine("*********************************************************");
Console.ResetColor();
*/
//************************************************************************************* Practice Problems *********************************************************************// 
/*
1. Build an app that fetches weather data for 3 cities concurrently using Task.WhenAll and an injected IWeatherService.
2. Create a tool that reads three different text files asynchronously using Task.Run and an injected IFileService to count the total words.
3. Develop a system that sends "Welcome" emails to a list of users asynchronously using an injected IEmailService (simulated with Task.Delay).
4. Build a program that fetches a user's "Profile Data" and "Order History" from two different async methods using an injected IUserRepository.
5. Create a console app that fetches the current price of 5 different stocks concurrently using an injected IStockService.
*/
//Solution:
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; // Added for File I/O

namespace AsyncDI_Practice
{
    // INTERFACES
    public interface IWeatherService 
    { 
        Task<string> GetWeatherAsync(string city); 
    }
    public interface IFileService { 
        void CreateDummyFiles(); 
        string ReadText(string path); 
    } 
    public interface IEmailService 
    { 
        Task SendEmailAsync(string user); 
    }
    public interface IUserRepository 
    { 
        Task<string> GetProfileAsync(int id); 
        Task<string> GetOrdersAsync(int id); 
    }
    public interface IStockService 
    { 
        Task<decimal> GetPriceAsync(string symbol); 
    }

    // IMPLEMENTATIONS
    
    public class WeatherService : IWeatherService {
        public async Task<string> GetWeatherAsync(string city) {
            await Task.Delay(500); 
            return $"Weather in {city}: 22°C";
        }
    }

    public class FileService : IFileService {
        public void CreateDummyFiles() {
            File.WriteAllText("file1.txt", "The quick brown fox");
            File.WriteAllText("file2.txt", "Jumps over the lazy dog");
            File.WriteAllText("file3.txt", "Coding in C# is fun");
            Console.WriteLine("[System] Dummy files created on disk.");
        }

        public string ReadText(string path) {
            return File.ReadAllText(path); 
        }
    }

    public class EmailService : IEmailService {
        public async Task SendEmailAsync(string user) {
            await Task.Delay(100); 
            Console.WriteLine($"Email sent to {user}!");
        }
    }

    public class UserRepository : IUserRepository {
        public async Task<string> GetProfileAsync(int id) 
        { 
            await Task.Delay(500); 
            return $"Profile for User {id}"; 
        }
        public async Task<string> GetOrdersAsync(int id) 
        { 
            await Task.Delay(500); 
            return $"Orders for User {id}: [Order1, Order2]"; 
        }
    }

    public class StockService : IStockService {
        public async Task<decimal> GetPriceAsync(string symbol) {
            await Task.Delay(500);
            return (decimal)new Random().NextDouble() * 100;
        }
    }

    // MANAGERS
    public class WeatherManager {
        private readonly IWeatherService _service;
        public WeatherManager(IWeatherService service) => _service = service;
        public async Task RunAsync() {
            var cities = new[] { "London", "New York", "Tokyo" };
            var tasks = cities.Select(c => _service.GetWeatherAsync(c));
            var results = await Task.WhenAll(tasks);
            Console.WriteLine($"[Weather] {string.Join(", ", results)}");
        }
    }

    public class FileManager {
        private readonly IFileService _myPermanentStorage;
        public FileManager(IFileService temporaryDelivery) 
        {
            _myPermanentStorage = temporaryDelivery;
        }
        public async Task RunAsync() {
            var files = new[] { "file1.txt", "file2.txt", "file3.txt" };
            
            // Task.Run is used here to move the synchronous File.ReadAllText off the main thread
            var tasks = files.Select(f => Task.Run(() => _myPermanentStorage.ReadText(f))).ToList();
            
            var contents = await Task.WhenAll(tasks);
            int totalWords = contents.Sum(text => text.Split(' ').Length);
            Console.WriteLine($"[Files] Total words read from disk: {totalWords}");
        }
    }

    public class EmailManager {
        private readonly IEmailService _service;
        public EmailManager(IEmailService service)
        {
            _service = service;
        } 
        public async Task RunAsync() {
            var users = new[] { "Alice", "Bob", "Charlie" };
            foreach (var user in users) await _service.SendEmailAsync(user);
            Console.WriteLine("[Email] All welcome emails sent.");
        }
    }

    public class UserManager {
        private readonly IUserRepository _repo;
        public UserManager(IUserRepository repo) 
        { 
            _repo = repo;
        }
        public async Task RunAsync() {
            var profileTask = _repo.GetProfileAsync(1);
            var ordersTask = _repo.GetOrdersAsync(1);
            await Task.WhenAll(profileTask, ordersTask);
            Console.WriteLine($"[User] {profileTask.Result} | {ordersTask.Result}");
        }
    }

    public class StockManager {
        private readonly IStockService _service;
        public StockManager(IStockService service) 
        {
             _service = service;
        }
        public async Task RunAsync() {
            var stocks = new[] { "ADBL", "NHPC", "ALG", "HRI", "BLA" };
            var tasks = stocks.Select(s => _service.GetPriceAsync(s));
            var prices = await Task.WhenAll(tasks);
            Console.WriteLine($"[Stocks] Average Price: {prices.Average():C2}");
        }
    }

    // MAIN EXECUTION
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Async/DI Practice Application...\n");

            // --- File Setup ---
            // We create the service first to set up the physical files on the disk
            FileService actualFileService = new FileService();
            actualFileService.CreateDummyFiles();

            // 1: Weather
            var weatherMgr = new WeatherManager(new WeatherService());
            await weatherMgr.RunAsync();

            // 2: Files (Injecting the service that already created the files)
            var fileMgr = new FileManager(actualFileService);
            await fileMgr.RunAsync();

            // 3: Emails
            var emailMgr = new EmailManager(new EmailService());
            await emailMgr.RunAsync();

            // 4: User Data
            var userMgr = new UserManager(new UserRepository());
            await userMgr.RunAsync();

            // 5: Stocks
            var stockMgr = new StockManager(new StockService());
            await stockMgr.RunAsync();

            Console.WriteLine("\nAll tasks completed!");
        }
    }
}
*/