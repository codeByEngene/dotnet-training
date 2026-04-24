//.Net IOC Container
/*
Imagine a company that hires a new Employee. To do their job, every employee needs a Laptop.

Normal Control (The "Hard Way"): The Employee is told, "You are hired! Now, go to the electronics store, find a laptop you like, buy it with your own money, install the software, and then start working."

The Problem: The employee is now "coupled" to that specific laptop. If the company decides everyone must use a Mac instead of a Windows PC, the employee has to go back to the store, sell their laptop, and buy a new one. The employee is spending their time managing equipment instead of doing their actual job.
Inversion of Control (The "Smart Way"): The Employee is told, "You are hired! Just tell HR what kind of role you have, and they will hand you a pre-configured laptop on your first day."

The Benefit: The employee doesn't care where the laptop came from or how it was bought. They just receive a tool that fits the "Laptop" description. If the company changes its hardware provider, HR simply hands out different laptops. The employee's job description doesn't change.
In this analogy:

The Employee = The Class.
The Laptop = The Dependency.
HR Department = The IoC Container.
*/


//Example:

/*
using System;

namespace IoC_Beginner_Example
{
    // Think of this as a "Battery Slot." 
    // Any laptop that wants to be used by an employee MUST follow this rule.
    public interface ILaptop
    {
        void Use();
    }

    // Option A: A MacBook
    public class MacBook : ILaptop
    {
        public void Use() => Console.WriteLine("Working on a MacBook... (Fast and Sleek!)");
    }

    // Option B: A Dell Laptop
    public class DellLaptop : ILaptop
    {
        public void Use() => Console.WriteLine("Working on a Dell... (Reliable and Robust!)");
    }

    // The Employee

    public class Employee
    {
        private readonly ILaptop _laptop;

        // CONSTRUCTOR INJECTION
        // Notice: The employee does NOT say "new MacBook()".
        // Instead, they say: "I just need ANY laptop that follows the ILaptop rule."
        public Employee(ILaptop laptop)
        {
            _laptop = laptop;
        }

        public void DoWork()
        {
            Console.WriteLine("Employee is starting their day...");
            _laptop.Use(); // Use whatever laptop was handed to them
        }
    }

    // THE "MANAGER" (The Simple IoC Container)
    // The HR Manager is in control. They decide which tool the employee gets.
    public class HRManager
    {
        // This variable decides the "Company Standard"
        public string CompanyPolicy = "MacBook"; 

        public Employee HireEmployee()
        {
            ILaptop assignedLaptop;

            // The Manager decides the implementation based on the policy
            if (CompanyPolicy == "MacBook")
            {
                assignedLaptop = new MacBook();
            }
            else
            {
                assignedLaptop = new DellLaptop();
            }

            // The Manager "Injects" the laptop into the Employee's constructor
            return new Employee(assignedLaptop);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create the HR Manager
            HRManager hr = new HRManager();

            // --- Scenario A: Company uses MacBooks ---
            Console.WriteLine("--- SCENARIO A: MacBook Policy ---");
            //hr.CompanyPolicy = "MacBook"; // Set policy
            
            Employee emp1 = hr.HireEmployee(); // HR handles the laptop and the hire
            emp1.DoWork(); 
            // Result: Working on a MacBook...

            Console.WriteLine("\n------------------------------------------\n");

            // --- Scenario B: Company switches to Dell ---
            Console.WriteLine("--- SCENARIO B: Dell Policy ---");
            hr.CompanyPolicy = "Dell"; // Set policy
            
            Employee emp2 = hr.HireEmployee(); // HR handles the laptop and the hire
            emp2.DoWork(); 
            // Result: Working on a Dell...
        }
    }
}
*/



//Dependency Injection Life Time
//In large apps, manually writing new Class(new Service()) becomes a nightmare. 
//The IoC Container acts as a "Automatic Factory" that manages the creation and lifetime of all objects.
//Note: This requires the NuGet package: Microsoft.Extensions.DependencyInjection
/*
1. Transient (The "Disposable")
Definition: A new instance is created every single time it is requested.

Analogy: Like a disposable coffee cup. You get a brand new one every time you order a coffee. You use it once and throw it away.
Best for: Lightweight, stateless services (e.g., a Calculator, a Formatting tool).
C# Registration: services.AddTransient<IMyService, MyService>();

2. Scoped (The "Per-Request")
Definition: A new instance is created once per client request (e.g., one per HTTP request in a web app). All classes within that same request share the same instance.

Analogy: Like a restaurant table. Everyone sitting at "Table 5" shares the same breadbasket for the duration of their meal. Once the party leaves and the bill is paid, the breadbasket is cleared away.
Best for: Database contexts (DbContext), User session info, or anything that should be consistent for one user's single action.
C# Registration: services.AddScoped<IMyService, MyService>();

3. Singleton (The "One and Only")
Definition: A single instance is created the first time it is requested and that same instance is used everywhere for the entire life of the application until it shuts down.

Analogy: Like the front door of the building. There is only one door. Every single person who enters or leaves the building uses that exact same door.
Best for: Caching services, Configuration settings, or shared state.
C# Registration: services.AddSingleton<IMyService, MyService>();
*/

// The Problem
/*
// Manual DI is a nightmare of "new" keywords
var dbContext = new DatabaseContext(); 
var repo = new UserRepository(dbContext); 
var service = new UserService(repo); 
var controller = new UserController(service); 

controller.DoWork();


What happens if you decide that UserService now also needs an IEmailService? 
You have to go back to Main and change the line where you create the UserService. 
And if UserService is used in 10 different places in your app, you have to fix it in 10 different places.

Object Graph Problem: 
As your app grows, the number of "new" statements and manual wiring becomes unmanageable.

*/

//Usage if DI Container Could be used
/*
using System;
using Microsoft.Extensions.DependencyInjection; // The "Magic Box" library

namespace DI_Simple_Explanation
{
    // Bottom of the chain
    public interface IDatabase { void Connect(); }
    // Middle of the chain
    public interface IRepository { void Save(); }
    // Top of the chain
    public interface IOrderProcessor { void Process(); }

    // THE IMPLEMENTATIONS 
    public class SqlDatabase : IDatabase {
        public void Connect() => Console.WriteLine("Database: Connected to SQL Server.");
    }

    public class OrderRepository : IRepository {
        private readonly IDatabase _db;
        // CONSTRUCTOR INJECTION: Needs the database to work
        public OrderRepository(IDatabase db) => _db = db;

        public void Save() {
            _db.Connect();
            Console.WriteLine("Repository: Order saved to DB.");
        }
    }

    public class OrderProcessor : IOrderProcessor {
        private readonly IRepository _repo;
        // CONSTRUCTOR INJECTION: Needs the repository to work
        public OrderProcessor(IRepository repo) => _repo = repo;

        public void Process() {
            Console.WriteLine("Processor: Validating order...");
            _repo.Save();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // STEP A: THE MAPPING (The Registration)
            // ------------------------------------------------------------
            // We create a collection and simply "map" the interface to the class.
            // Think of this as a phone book: "If you need IDatabase, call SqlDatabase."
            var services = new ServiceCollection();

            services.AddTransient<IDatabase, SqlDatabase>(); 
            services.AddTransient<IRepository, OrderRepository>(); 
            services.AddTransient<IOrderProcessor, OrderProcessor>(); 

            // Build the container (the actual Magic Box)
            var container = services.BuildServiceProvider();

            // THE RESOLUTION            
            Console.WriteLine("Requesting OrderProcessor from the container...\n");

            // We only ask for the TOP object.
            // We DO NOT provide the Repository or the Database here.
            // The container uses REFLECTION to see:
            // 1. OrderProcessor needs IRepository -> looks up OrderRepository
            // 2. OrderRepository needs IDatabase -> looks up SqlDatabase
            // 3. It builds them from bottom-up and plugs them in automatically.
            
            var processor = container.GetRequiredService<IOrderProcessor>();

            // Start the chain reaction
            processor.Process();
        }
    }
}
*/

//Dependency Injection Life Time 
/*
using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Lifetimes_Explanation
{
    // THE INTERFACES & IMPLEMENTATIONS    
    // We create three interfaces to represent the three lifetimes
    public interface ITransientService { Guid GetId(); }
    public interface ISingletonService { Guid GetId(); }
    public interface IScopedService { Guid GetId(); }

    // Each implementation creates a Unique ID in its constructor
    public class TransientService : ITransientService {
        private readonly Guid _id = Guid.NewGuid(); // Created every time 'new' is called
        public Guid GetId() => _id;
    }

    public class SingletonService : ISingletonService {
        private readonly Guid _id = Guid.NewGuid(); // Created only once
        public Guid GetId() => _id;
    }

    public class ScopedService : IScopedService {
        private readonly Guid _id = Guid.NewGuid(); // Created once per "Scope"
        public Guid GetId() => _id;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // "Always run 'new' every time this is requested"
            services.AddTransient<ITransientService, TransientService>();

            // "Run 'new' ONLY ONCE. Keep it in memory forever."
            services.AddSingleton<ISingletonService, SingletonService>();

            // "Run 'new' once per Scope. Shared within the scope, new for the next scope."
            services.AddScoped<IScopedService, ScopedService>();

            var container = services.BuildServiceProvider();

            // we create a "Scope" (Imagine this as one single HTTP request in a Web API)
            using (var scope1 = container.CreateScope())
            {
                var provider = scope1.ServiceProvider;
                Console.WriteLine("--- Scope 1 ---");
                
                // Requesting twice within the same scope
                Console.WriteLine($"Transient 1: {provider.GetRequiredService<ITransientService>().GetId()}");
                Console.WriteLine($"Transient 2: {provider.GetRequiredService<ITransientService>().GetId()}"); // Will be DIFFERENT
                
                Console.WriteLine($"Singleton 1: {provider.GetRequiredService<ISingletonService>().GetId()}");
                Console.WriteLine($"Singleton 2: {provider.GetRequiredService<ISingletonService>().GetId()}"); // Will be SAME
                
                Console.WriteLine($"Scoped 1:    {provider.GetRequiredService<IScopedService>().GetId()}");
                Console.WriteLine($"Scoped 2:    {provider.GetRequiredService<IScopedService>().GetId()}"); // Will be SAME
            }

            Console.WriteLine("\n--------------------------\n");

            // Create a SECOND "Scope" (Imagine a second user visiting the website)
            using (var scope2 = container.CreateScope())
            {
                var provider = scope2.ServiceProvider;
                Console.WriteLine("--- Scope 2 ---");
                
                Console.WriteLine($"Transient 3: {provider.GetRequiredService<ITransientService>().GetId()}"); // DIFFERENT again
                
                Console.WriteLine($"Singleton 3: {provider.GetRequiredService<ISingletonService>().GetId()}"); // Still the SAME as Scope 1
                
                Console.WriteLine($"Scoped 3:    {provider.GetRequiredService<IScopedService>().GetId()}"); // DIFFERENT from Scope 1
            }
        }
    }
}
*/


//Real Life Scenerio - eCommerce Order Processing with DI Lifetimes
/*
using System;
using Microsoft.Extensions.DependencyInjection;

namespace RealWorldDI_Example
{

    public interface IDatabase { void ExecuteQuery(string query); Guid GetId(); }
    public interface IOrderRepository { void SaveOrder(int orderId); Guid GetId(); }
    public interface INotificationService { void SendNotification(string msg); Guid GetId(); }



    // SINGLETON: Imagine this as a heavy connection pool that stays open for the app's life
    public class SqlDatabase : IDatabase {
        private readonly Guid _id = Guid.NewGuid();
        public void ExecuteQuery(string query) => Console.WriteLine($"[DB] Executing: {query}");
        public Guid GetId() => _id;
    }

    // SCOPED: This handles data for a specific customer's request
    public class OrderRepository : IOrderRepository {
        private readonly IDatabase _db; // Injected Singleton
        private readonly Guid _id = Guid.NewGuid();

        public OrderRepository(IDatabase db) => _db = db;

        public void SaveOrder(int orderId) {
            _db.ExecuteQuery($"INSERT INTO Orders VALUES ({orderId})");
            Console.WriteLine($"[Repo] Order {orderId} saved using Repo ID: {_id}");
        }
        public Guid GetId() => _id;
    }

    // TRANSIENT: A lightweight service that just sends a message and is forgotten
    public class EmailNotificationService : INotificationService {
        private readonly Guid _id = Guid.NewGuid();
        public void SendNotification(string msg) => Console.WriteLine($"[Email] Sending: {msg} using Service ID: {_id}");
        public Guid GetId() => _id;
    }


    public class OrderProcessor {
        private readonly IOrderRepository _repo;
        private readonly INotificationService _notifier;

        // Constructor Injection: The processor doesn't care HOW these are created, just that they work.
        public OrderProcessor(IOrderRepository repo, INotificationService notifier) {
            _repo = repo;
            _notifier = notifier;
        }

        public void ProcessOrder(int orderId) {
            Console.WriteLine($"\n--- Processing Order {orderId} ---");
            _repo.SaveOrder(orderId);
            _notifier.SendNotification($"Order {orderId} has been placed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // DB is expensive -> One for the whole app
            services.AddSingleton<IDatabase, SqlDatabase>();

            // Repo is request-based -> One per "Order Process"
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Email is cheap -> New one every time
            services.AddTransient<INotificationotificationService, EmailNotificationService>();

            // The Processor itself is also registered
            services.AddTransient<OrderProcessor>();

            var container = services.BuildServiceProvider();



            // Customer 1 Request
            using (var scope1 = container.CreateScope())
            {
                Console.WriteLine("=== CUSTOMER 1 REQUEST START ===");
                var processor = scope1.ServiceProvider.GetRequiredService<OrderProcessor>();
                processor.ProcessOrder(101);
                
                // Let's check if we get the same Repo if we ask for it again in the same request
                var repo1 = scope1.ServiceProvider.GetRequiredService<IOrderRepository>();
                var repo2 = scope1.ServiceProvider.GetRequiredService<IOrderRepository>();
                Console.WriteLine($"Scoped Repo ID match? {repo1.GetId() == repo2.GetId()}"); // TRUE
                Console.WriteLine("=== CUSTOMER 1 REQUEST END ===\n");
            }

            // Customer 2 Request
            using (var scope2 = container.CreateScope())
            {
                Console.WriteLine("=== CUSTOMER 2 REQUEST START ===");
                var processor = scope2.ServiceProvider.GetRequiredService<OrderProcessor>();
                processor.ProcessOrder(102);
                
                var repo3 = scope2.ServiceProvider.GetRequiredService<IOrderRepository>();
                Console.WriteLine($"Is this Repo the same as Customer 1's? No. New ID: {repo3.GetId()}");
                Console.WriteLine("=== CUSTOMER 2 REQUEST END ===");
            }
            
            // Final Proof: The Database ID
            var db1 = container.GetRequiredService<IDatabase>().GetId();
            var db2 = container.GetRequiredService<IDatabase>().GetId();
            Console.WriteLine($"\nDatabase Singleton ID match? {db1 == db2}"); // TRUE (Always same)
        }
    }
}

*/


/**************************************** One Interface, Multiple Implementations *****************************************/
/*
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace MultipleDI_Example
{
    // 1. The Contract
    public interface INotificationService { void Send(string message); }

    // 2. First Implementation
    public class EmailService : INotificationService {
        public void Send(string message) => Console.WriteLine($"[Email] Sending: {message}");
    }

    // 3. Second Implementation
    public class SmsService : INotificationService {
        public void Send(string message) => Console.WriteLine($"[SMS] Sending: {message}");
    }

    // 4. Third Implementation
    public class PushService : INotificationService {
        public void Send(string message) => Console.WriteLine($"[Push] Sending: {message}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // REGISTERING MULTIPLE IMPLEMENTATIONS FOR THE SAME INTERFACE
            services.AddTransient<INotificationService, EmailService>();
            services.AddTransient<INotificationService, SmsService>();
            services.AddTransient<INotificationService, PushService>(); // Last one registered

            var container = services.BuildServiceProvider();


            // The container will only return the LAST one registered (PushService).
            var singleService = container.GetRequiredService<INotificationService>();
            Console.WriteLine("Case 1: Requesting a single service...");
            singleService.Send("Hello!"); 
            // Output: [Push] Sending: Hello!
            
            Console.WriteLine("\n----------------------------\n");

            // By asking for IEnumerable<T>, the container returns a list of EVERY 
            // implementation registered for that interface.
            Console.WriteLine("Case 2: Requesting ALL notification services...");
            var allServices = container.GetRequiredService<IEnumerable<INotificationService>>();

            foreach (var service in allServices)
            {
                service.Send("Critical System Alert!");
            }
            //    Output:
            //    [Email] Sending: Critical System Alert!
            //    [SMS] Sending: Critical System Alert!
            //    [Push] Sending: Critical System Alert!
            
        }
    }
}
*/

//What if i want to only send email 
// Method 1 - Classic 
/*
using System;
using System.Collections.Generic;
using System.Linq; // Required for .OfType()
using Microsoft.Extensions.DependencyInjection;

namespace ClassicDI_Example
{
    public interface INotificationService { void Send(string msg); }
    public class EmailService : INotificationService { public void Send(string msg) => Console.WriteLine($"[Email] {msg}"); }
    public class SmsService : INotificationService { public void Send(string msg) => Console.WriteLine($"[SMS] {msg}"); }

    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<INotificationService, EmailService>();
            services.AddTransient<INotificationService, SmsService>();
            var container = services.BuildServiceProvider();

            // 1. Ask for ALL registered notification services
            var allServices = container.GetRequiredService<IEnumerable<INotificationService>>();

            // 2. Use LINQ to find the one that is specifically an EmailService
            var emailService = allServices.OfType<EmailService>().FirstOrDefault();

            if (emailService != null)
            {
                emailService.Send("This is filtered email!");
            }
        }
    }
}
*/
/*
//Method 2: Keyed Service

using System;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedDI_Example
{
    public interface INotificationService { void Send(string msg); }
    public class EmailService : INotificationService { public void Send(string msg) => Console.WriteLine($"[Email] {msg}"); }
    public class SmsService : INotificationService { public void Send(string msg) => Console.WriteLine($"[SMS] {msg}"); }

    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            // We register them with "Keys" (nicknames)
            services.AddKeyedTransient<INotificationService, EmailService>("email");
            services.AddKeyedTransient<INotificationService, SmsService>("sms");

            var container = services.BuildServiceProvider();

            // Instead of GetRequiredService, we use GetRequiredKeyedService
            // "Give me the INotificationService that has the key 'email'"
            var emailService = container.GetRequiredKeyedService<INotificationService>("email");
            
            emailService.Send("This is a specific email!"); 
            // Output: [Email] This is a specific email!
        }
    }
}
*/

//Method 3: Factory Pattern
/*
public class NotificationFactory {
    private readonly IEnumerable<INotificationService> _services;
    public NotificationFactory(IEnumerable<INotificationService> services) => _services = services;

    public INotificationService GetService(string type) {
        return type.ToLower() switch {
            "email" => _services.OfType<EmailService>().FirstOrDefault(),
            "sms" => _services.OfType<SmsService>().FirstOrDefault(),
            _ => throw new Exception("Service not found")
        };
    }
}
*/
//Full Example:
/*
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryDI_Example
{
    // 1. THE CONTRACTS
    public interface INotificationService { void Send(string msg); }
    public class EmailService : INotificationService { public void Send(string msg) => Console.WriteLine($"[Email] {msg}"); }
    public class SmsService : INotificationService { public void Send(string msg) => Console.WriteLine($"[SMS] {msg}"); }

    // 2. THE FACTORY (Your provided code)
    public class NotificationFactory {
        private readonly IEnumerable<INotificationService> _services;

        // The Container automatically injects ALL registered INotificationServices into this list
        public NotificationFactory(IEnumerable<INotificationService> services) => _services = services;

        public INotificationService GetService(string type) {
            return type.ToLower() switch {
                "email" => _services.OfType<EmailService>().FirstOrDefault(),
                "sms" => _services.OfType<SmsService>().FirstOrDefault(),
                _ => throw new Exception("Service not found")
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // Register the actual tools (The "Workers")
            services.AddTransient<INotificationService, EmailService>();
            services.AddTransient<INotificationService, SmsService>();

            // Register the Factory (The "Manager")
            // Notice: We register the factory class itself
            services.AddTransient<NotificationFactory>();

            var container = services.BuildServiceProvider();


            // 1. Ask the container for the Factory
            var factory = container.GetRequiredService<NotificationFactory>();

            // 2. Use the factory to get the specific service you want
            // You can now decide AT RUNTIME which service to use
            Console.WriteLine("Asking factory for Email...");
            var email = factory.GetService("email");
            email.Send("Hello via Factory Email!");

            Console.WriteLine("\nAsking factory for SMS...");
            var sms = factory.GetService("sms");
            sms.Send("Hello via Factory SMS!");
        }
    }
}
*/


/**************************************** Yield Keyword *****************************************/
//The yield keyword is used in C# to create Iterators. An iterator is a method that returns a sequence of values one by one, rather than returning an entire collection (like a List or Array) all at once.
//The most important concept to understand with yield is Deferred Execution (also known as Lazy Loading). The code inside a yield method does not run immediately when the method is called; it runs only when you actually loop through the results (e.g., using a foreach loop).

//Yield Return
//Example
/*
using System;
using System.Collections.Generic;

public class YieldDemo
{
    public static void Main()
    {
        Console.WriteLine("Calling GetNumbers()...");
        // NOTE: The method GetNumbers is NOT executed yet. 
        // It only creates an "iterator" object.
        IEnumerable<int> numbers = GetNumbers(); 
        
        Console.WriteLine("Starting the foreach loop:");
        foreach (int num in numbers)
        {
            Console.WriteLine($"Received: {num}");
            // The code jumps back into the GetNumbers method 
            // every time the loop asks for the next item.
        }
    }

    public static IEnumerable<int> GetNumbers()
    {
        Console.WriteLine("--- Generating 1 ---");
        yield return 1; // Method pauses here and returns 1 to the loop

        Console.WriteLine("--- Generating 2 ---");
        yield return 2; // Method resumes here and returns 2 to the loop

        Console.WriteLine("--- Generating 3 ---");
        yield return 3; // Method resumes here and returns 3 to the loop
    }
}
*/


//Yield Break
//yield break is used to tell the iterator to stop immediately. It signifies that there are no more elements in the sequence.
/*
using System;
using System.Collections.Generic;

public class YieldBreakDemo
{
    public static void Main()
    {
        var numbers = new GetNumbersUntilNegative();
        // Get numbers until we hit a negative number
        foreach (int num in numbers)
        {
            Console.WriteLine($"Processing: {num}");
        }
        Console.WriteLine("Iteration stopped.");
    }

    public static IEnumerable<int> GetNumbersUntilNegative()
    {
        yield return 10;
        yield return 20;
        yield return -1; // We decide to stop if we hit -1
        
        
        // Logic to stop the sequence
        if (false)  
        
        // This terminates the iterator entirely
        yield break; 
        
        yield return 30; // This line will NEVER be reached
    }
}
*/

//Real Life Scenario: Reading Lines from a Large File
//Imagine you have a file with 1 million rows. If you load them all into a List<string>, you might run out of memory (RAM). With yield, you process one row at a time.
/*
using System;
using System.Collections.Generic;
using System.Linq;

public class DataProcessor
{
    public static void Main()
    {
        List<int> data = new List<int>();
        // We only process the "Even" numbers. 
        // No matter how big the source is, we only hold one item in memory at a time.
        foreach (var item in FilterEvenNumbers(10))
        {
            data.Add(item); // We can choose to store it or just process it
            Console.WriteLine($"Found Even: {item}");
        }
        
        Console.WriteLine($"Total even numbers found: {data.Count}");
    }

    public static IEnumerable<int> FilterEvenNumbers(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            // if(i == 3)
            // {
            //     yield break; // Stop the entire sequence if we hit 3 (for demonstration)
            // }
            if (i % 2 == 0)
            {
                yield return i; // Return only if it matches the condition
            }
            // If it's odd, the loop continues without returning anything,
            // and the foreach loop just waits for the next valid 'yield return'.
        }
    }
}
*/


//When To Use Yield
/*
//If you are reading a 1GB text file or querying 1 million rows from a database, creating a List<T> will consume massive amounts of RAM and may cause an OutOfMemoryException.
//Without yield: You read all 1 million lines into a list, then return the list. Your RAM usage spikes immediately.
//With yield: You read one line, return it, and "forget" it. Your RAM usage stays flat regardless of whether the file is 1MB or 1TB.

//1. Working with huge data sets (e.g., reading large files, streaming data) Memory Efficient.


public IEnumerable<string> ReadLargeLogFile(string path) {
    foreach (var line in File.ReadLines(path)) {
        if (line.Contains("ERROR")) {
            yield return line; // Only the current line is in memory
        }
    }
}

//2. Improving "Time-to-First-Item" (Latency)
When you return a List<T>, the caller must wait for the entire list to be populated before they can see the first item. With yield, the caller can start processing the first item the moment it is found.

The Difference:

List<T>: [Wait for 1... Wait for 2... Wait for 3...] -> [Return whole list] -> [Caller starts processing]
yield: [Find 1] -> [Caller processes 1] -> [Find 2] -> [Caller processes 2]
Use this when: You are building a UI search bar or a data stream where the user shouldn't be staring at a frozen screen while the whole list is generated.


//3. Creating Infinite Sequences 
You cannot return a List of all prime numbers because that list is infinite. However, you can use yield to create a generator that produces the "next" prime number only when requested.

public IEnumerable<long> GetFibonacci() {
    long a = 0, b = 1;
    while (true) { // Infinite loop!
        yield return a;
        long temp = a;
        a = b;
        b = temp + b;
    }
}

// The user decides when to stop by using .Take() or a break
foreach (var num in GetFibonacci().Take(10)) { 
    Console.WriteLine(num); 
}
*/

//Full Example
/*
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "sample.txt";

        // STEP 1: Create a file with custom content
        CreateSampleFile(filePath);

        Console.WriteLine("=== Reading file using YIELD ===");

        // STEP 2: Get lazy enumerable (no file read yet)
        var lines = ReadFileLazy(filePath);

        // STEP 3: Process line-by-line
        foreach (var line in lines)
        {
            Console.WriteLine($"Read: {line}");

            // Example logic: stop early if condition met
            if (line.Contains("STOP"))
            {
                Console.WriteLine("STOP found → breaking early");
                break; // stops reading file immediately
            }

            // Example logic: filter
            if (line.Contains("ERROR"))
            {
                Console.WriteLine("⚠ Error detected!");
            }
        }
    }

    // Create a sample file with custom content
    static void CreateSampleFile(string path)
    {
        var content = new List<string>
        {
            "INFO: Application started",
            "INFO: Loading modules",
            "ERROR: Failed to load config",
            "INFO: Retrying...",
            "INFO: Running process",
            "STOP: Critical issue occurred",
            "INFO: This line should NOT be read"
        };

        File.WriteAllLines(path, content);

        Console.WriteLine("Sample file created.\n");
    }

    // Read file using yield (LAZY execution)
    static IEnumerable<string> ReadFileLazy(string path)
    {
        using (var reader = new StreamReader(path))
        {
            string line;

            // Loop through file
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Producing: {line}");

                yield return line; 
                // Return ONE line at a time
                // Pause here until next iteration
            }
        }
        // File closes automatically when done or loop breaks
    }
}
*/
