//*************************************************** Generics ******************************************************//
//Imagine we want a method that swaps two values. Without generics, we have to write 
// a new method for every single data type.

//Generic Methods 
/*
using System;

class Program
{
    // Swap method specifically for Integers
    static void SwapInts(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Swap method specifically for Strings
    static void SwapStrings(ref string a, ref string b)
    {
        string temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        int x = 10, y = 20;
        SwapInts(ref x, ref y);
        Console.WriteLine($"Ints swapped: {x}, {y}");

        string firstName = "John", lastName = "Doe";
        SwapStrings(ref firstName, ref lastName);
        Console.WriteLine($"Strings swapped: {firstName}, {lastName}");
        
        // PROBLEM: What if we need to swap doubles? Booleans? 
        // We have to keep writing new methods! This is "Code Duplication."
    }
}

// Solution
// Instead of saying int or string, we use T. 
// When the user calls the method, C# replaces T with the actual type they are using.
using System;

class Program
{
    // <T> tells C# that this method is generic. 
    // 'T' is a placeholder for "whatever type the user provides."
    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a; // temp will be of type T
        a = b;
        b = temp;
    }

    static void Main()
    {
        // Example 1: Using it with integers
        int x = 10, y = 20;
        Swap<int>(ref x, ref y); // We explicitly tell it T is an 'int'
        Console.WriteLine($"Ints: {x}, {y}");

        // Example 2: Using it with strings
        string firstName = "John", lastName = "Doe";
        Swap<string>(ref firstName, ref lastName); // T is now a 'string'
        Console.WriteLine($"Strings: {firstName}, {lastName}");

        // Example 3: Type Inference
        // C# is smart! It can guess the type, so you don't always need <string>
        double d1 = 1.1, d2 = 2.2;
        Swap(ref d1, ref d2); 
        Console.WriteLine($"Doubles: {d1}, {d2}");
    }
}


/*
//Generic Classes
// A generic class can hold any type of data. 
//This is perfect for "Containers" (classes that store, wrap, or manage data)
*/
/*
using System;

// This class can store one piece of data of ANY type
class DataStore<T>
{
    private T _data;

    // Method to save data
    public void Save(T item)
    {
        _data = item;
        Console.WriteLine($"Data of type {typeof(T)} saved successfully.");
    }

    // Method to retrieve data
    public T Get()
    {
        return _data;
    }
}

public class CompanyDetails
{
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a store specifically for Integers
        DataStore<int> intStore = new DataStore<int>();
        intStore.Save(100);
        Console.WriteLine($"Retrieved: {intStore.Get()}");

        Console.WriteLine("-------------------");

        // Create a store specifically for Strings
        DataStore<string> stringStore = new DataStore<string>();
        stringStore.Save("Hello Generics!");
        Console.WriteLine($"Retrieved: {stringStore.Get()}");


        //object generic store
        DataStore<CompanyDetails> companyStore = new DataStore<CompanyDetails>();
        companyStore.Save(new CompanyDetails { Name = "Tech Corp", EmployeeCount = 500 });
        CompanyDetails details = companyStore.Get();
        Console.WriteLine($"Company: {details.Name}, Employees: {details.EmployeeCount}");
    }
}
*/

//Multiple Type Parameters
/*
using System;

// We use T1 and T2 to represent two different types
class Pair<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }

    public Pair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }

    public void Display()
    {
        Console.WriteLine($"First: {First} | Second: {Second}");
    }
}

class Program
{
    static void Main()
    {
        // Case 1: String and Integer (Name and Age)
        Pair<string, int> person = new Pair<string, int>("Bob", 25);
        person.Display();

        // Case 2: Integer and Boolean (ID and IsActive status)
        Pair<int, bool> userStatus = new Pair<int, bool>(101, true);
        userStatus.Display();
    }
}
*/


/*
// Generics with constraints
// Sometimes we want to restrict the types that can be used with our generic class or method. For example, we might want to ensure that T is a class (reference type) or that it implements a certain interface. 
// This is where constraints come in.
*/
/*
using System;

class Program
{
    // We use 'where T : IComparable' because we want to compare two values.
    // Not all types can be compared (e.g., you can't compare two random Classes).
    // This ensures that whatever T is, it MUST support comparison.
    static T GetMax<T>(T val1, T val2) where T : IComparable
    {
        var result = val1.CompareTo(val2);
        // .CompareTo is a method provided by the IComparable interface
        if (val1.CompareTo(val2) > 0)
        {
            return val1;
        }
        return val2;
    }

    static void Main()
    {
        // This works because 'int' is comparable
        int maxInt = GetMax(10, 20);
        Console.WriteLine($"Max Int: {maxInt}");

        // This works because 'string' is comparable (alphabetical order)
        string maxStr = GetMax("Apple", "Zebra");
        Console.WriteLine($"Max String: {maxStr}");
        
        // If you tried to use a custom class that doesn't implement IComparable,
        // the code wouldn't even compile! This prevents runtime crashes.
    }
}
*/

//Real Life Case Scenerios
/*
using System;

// A generic response class to wrap any data coming from a database/API

public class PropertyResponse
{
    public string name {get; set;}
}

class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; } // This can be a User, a Product, a List, etc.

    public ApiResponse(bool success, string msg, T data)
    {
        IsSuccess = success;
        Message = msg;
        Data = data;
    }
}

class Program
{
    static void Main()
    {
        // The API returns a string message
        ApiResponse<string> nameResponse = new ApiResponse<string>(true, "Success", "John Doe");
        Console.WriteLine($"API Result: {nameResponse.Data}");

        // The API returns an integer ID
        ApiResponse<int> idResponse = new ApiResponse<int>(true, "Success", 5001);
        Console.WriteLine($"API ID: {idResponse.Data}");

        ApiResponse<PropertyResponse> propertyResponse = new ApiResponse<PropertyResponse>(true, "Success", new PropertyResponse { name = "My Property" });
    }
}
*/



//*************************************************** Task ******************************************************//
/*
Asynchronous programming allows your program to start a long-running task and "yield" the 
CPU to do other work while waiting for that task to complete. 
Once the task is finished, the program resumes where it left off.

keywords:
async: Marks a method as asynchronous, allowing it to use the await keyword inside.
await: Used to pause the execution of an async method until the awaited Task completes. It does not block the thread; instead, it allows other work to run while waiting.   


Task and Task<T>
Task: Represents a single operation that does not return a value (similar to void).
Task<T>: Represents an operation that will eventually return a value of type T.
*/

/*
//basic implementation
using System;
using System.Threading.Tasks;
using System.Net.Http;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting application...");

        // We call the async method and 'await' it
        string content = await DownloadWebsiteAsync("https://www.microsoft.com");

        Console.WriteLine($"Downloaded {content.Length} characters.");
        Console.WriteLine("Application finished.");
    }

    // 'async' modifier allows use of 'await'
    // 'Task<string>' means this method will eventually return a string
    static async Task<string> DownloadWebsiteAsync(string url)
    {
        Console.WriteLine("Downloading website... (this takes time)");

        using (HttpClient client = new HttpClient())
        {
            // await tells the program to pause here and free up the thread
            // until GetStringAsync is finished.
            string result = await client.GetStringAsync(url);
            
            return result;
        }
    }
}
*/

/*
//Running Task in parallel
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

class ParallelExample
{
    static async Task Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Start three tasks WITHOUT awaiting them immediately
        Task<string> task1 = DoWorkAsync("Task 1", 3000);
        Task<string> task2 = DoWorkAsync("Task 2", 1000);
        Task<string> task3 = DoWorkAsync("Task 3", 2000);

        string task5 = await DoWorkAsync("Task 5", 3000);
        string task6 = await DoWorkAsync("Task 6", 1000);
        string task7 = await DoWorkAsync("Task 7", 2000);

        Console.WriteLine("Tasks have been started. Waiting for all to finish...");

        // Task.WhenAll waits for all tasks in the list to complete
        string[] results = await Task.WhenAll(task1, task2, task3);

        stopwatch.Stop();

        foreach (var res in results)
        {
            Console.WriteLine(res);
        }

        // Total time will be ~3 seconds (the longest task), NOT 6 seconds.
        Console.WriteLine($"Total time elapsed: {stopwatch.ElapsedMilliseconds}ms");
    }

    static async Task<string> DoWorkAsync(string name, int delay)
    {
        await Task.Delay(delay); // Simulate work
        return $"{name} completed after {delay}ms";
    }
}
*/

/*
//handling exceptions in async methods
//Task.Run forces the code inside to run on a DIFFERENT thread (ThreadPool)

static async Task ProcessDataAsync()
{
    try
    {
        await Task.Run(() => {
            throw new InvalidOperationException("Something went wrong in the background!");
        });
    }
    catch (InvalidOperationException ex)
    {
        // Exceptions are "unwrapped" by await and caught here
        Console.WriteLine($"Caught exception: {ex.Message}");
    }
}
*/

/*
//Cancellation Tokens allow you to signal that an async operation should stop before it completes. 
//This is essential for long-running tasks or when the user wants to cancel an operation.
//await client.GetStringAsync(url).ConfigureAwait(false);
//Why? By default, await tries to return to the original "context" (e.g., the UI thread). 
//ConfigureAwait(false) tells the program it doesn't need to return to the original context, which improves performance and prevents deadlocks.
using System;
using System.Threading;
using System.Threading.Tasks;
class CancellationExample
{
    static async Task Main()
    {
        // 1. Create a CancellationTokenSource
        CancellationTokenSource cts = new CancellationTokenSource();

        // Start the task and pass the token
        Task downloadTask = DownloadWithCancelAsync(cts.Token);

        // Simulate user clicking "Cancel" after 2 seconds
        await Task.Delay(2000);
        Console.WriteLine("User clicked cancel. Cancelling task...");
        cts.Cancel(); 

        try 
        {
            await downloadTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was successfully cancelled.");
        }
    }

    static async Task DownloadWithCancelAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            // Check if cancellation was requested
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Downloading chunk {i}...");
            await Task.Delay(1000, token); // Pass token to Delay as well
        }
    }
}
*/

/*
//.Result or .Wait()
//Calling .Result or .Wait() on a task blocks the current thread until the task completes. This often leads to Deadlocks, especially in UI applications.
//Multithreading in C# tells the OS: "Please create a new Software Thread and schedule it onto a Hardware Thread/Core."
//Async/Await tells the OS: "I'm going to wait for the network; you can take this Software Thread off the CPU Core and let another thread use it until the data arrives." (This avoids wasting a CPU core's time on a thread that is just sitting there waiting).
Standard Await await SendEmailAsync(); $\rightarrow$ Program stops -> Waits for Email $\rightarrow$ Email finishes $\rightarrow$ Program continues. (User sees a freeze/pause)
The _ = Task.Run approach _ = Task.Run(async () => { await SendEmailAsync(); }); -> Program tells background thread to start $\rightarrow$ Program immediately continues to next line. (User sees zero pause)
*/


//Sending Email and Fire and Forget
/*
public void OnSendButtonClick()
{
    // 1. Give the user immediate feedback (Random Message)
    string[] messages = { "Sending your email...", "Working on it!", "Almost there...", "Dispatching mail..." };
    string randomMsg = messages[new Random().Next(messages.Length)];
    
    Console.WriteLine(randomMsg); 
    // Or if UI: myLabel.Text = randomMsg;

    // 2. Fire and Forget the email work
    // We use Task.Run to push the work to a background thread immediately
    // The '_' is a 'discard' variable, telling C# we intentionally aren't awaiting this.
    _ = Task.Run(async () => 
    {
        try 
        {
            await SendEmailAsync(); 
        }
        catch (Exception ex) 
        {
            // Since you don't care if it fails, we just log it.
            // IMPORTANT: You MUST have a try-catch here, or a crash in the 
            // background could kill your entire application.
            Console.WriteLine($"Background email failed: {ex.Message}");
        }
    });

    // 3. The code reaches here INSTANTLY.
    // The user is now free to do other things while the email sends.
    Console.WriteLine("You can keep using the app while we send the mail!");
}

public async Task SendEmailAsync()
{
    // Simulate network delay
    await Task.Delay(5000); 
    Console.WriteLine("Email actually sent in background!");
}
*/




/*
C# Basics (Variable, Data Types...)
Control Flow (If, Switch, Loops...)
Functions and Methods (Parameters, Return Types, Overloading)
How C# Works (Compilation, CLR, JIT)
OOP (Classes, Objects, Inheritance, Polymorphism)
Advanced OOP (Abstract Classes, Interfaces, Encapsulation, Exception Handling)
Collections
LINQ
File Operation IO
Struct, Records, Tuple, Delegates, Events
Generics (Generic Methods, Classes, Constraints)
Asynchronous Programming (async/await, Tasks, Cancellation)
*/

