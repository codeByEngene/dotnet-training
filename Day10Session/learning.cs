//*************************************************** Class And Struct ******************************************************//
/*
Classes and structs are both user-defined data types in C#, but they have some key differences:
1. Memory Allocation:
   - Class: Reference type, allocated on the heap. Variables hold a reference to the data.
   - Struct: Value type, allocated on the stack (or inline in containing types). Variables hold the actual data.
2. Inheritance:
    - Class: Supports inheritance. You can create a class hierarchy.
    - Struct: Does not support inheritance (except for interfaces). Cannot be a base or derived type.
3. Default Constructor:
    - Class: Can have a parameterless constructor that initializes fields.
    - Struct: Always has an implicit parameterless constructor that initializes fields to their default values. You cannot define your own parameterless constructor in a struct.
4. Mutability:
    - Class: Can be mutable or immutable based on how you design it.
    - Struct: Typically designed to be immutable, but can be mutable. However, mutable structs can lead to unexpected behavior, especially when passed to methods or used in collections.
5. Performance: 
    - Class: Generally better for larger data structures or when you need reference semantics.
    - Struct: Can be more efficient for small data structures (less than 16 bytes) due to reduced heap allocations and better cache locality.

When you create a class, the variable does not hold the actual data. Instead, it holds a reference (a pointer) to the memory address on the Heap where the data lives.


A struct holds the actual data itself. It is usually stored on the Stack.
The compiler creates a Defensive Copy (a hidden clone of the struct) every time you call a method on it. If your struct is large, creating thousands of these clones slows down your program.


Use a Class/Struct when:
The data structure is used throughout the entire application.
You need to add logic (methods/properties) to the data.
You have a large number of properties (more than 4-5), which makes tuples hard to manage.
You need to use inheritance.
*/
/*
using System;

// Definition of a Class
public class PointClass {
    public int X;
    public int Y;
}

// Definition of a Struct
public struct PointStruct {
    public int X;
    public int Y;
}

public class Program {
    public static void Main() {
        // --- CLASS BEHAVIOR ---
        PointClass c1 = new PointClass();
        c1.X = 10;
        
        PointClass c2 = c1; // c2 now points to the SAME memory address as c1
        c2.X = 50;          // Changing c2 also changes c1!

        Console.WriteLine($"Class c1.X: {c1.X}"); // Output: 50
        Console.WriteLine($"Class c2.X: {c2.X}"); // Output: 50

        Console.WriteLine("-------------------------");

        // --- STRUCT BEHAVIOR ---
        PointStruct s1 = new PointStruct();
        s1.X = 10;

        PointStruct s2 = s1; // A COMPLETE COPY of s1 is made and given to s2
        s2.X = 50;           // Changing s2 DOES NOT affect s1

        Console.WriteLine($"Struct s1.X: {s1.X}"); // Output: 10
        Console.WriteLine($"Struct s2.X: {s2.X}"); // Output: 50
    }
}
*/


//*************************************************** Tuple ******************************************************//
/*
A tuple is a data structure that groups multiple values of potentially different types into a single object — without needing to define a class or struct. 
C# supports two main kinds:
System.Tuple<> — the old reference-type tuple (C# 4+)
ValueTuple — the modern, lightweight value-type tuple with named fields (C# 7+)

Use a Tuple when:
You need to return multiple values from a method temporarily.
The grouping of data is only used internally within a method or a small class.
Creating a full class would be "overkill" (e.g., returning a (bool success, string message) from a validation method).
*/


/*
// Creating a Tuple the old way using Tuple.Create()
Tuple<int, string, bool> person = Tuple.Create(1, "Alice", true);

Console.WriteLine(person.Item1); // 1
Console.WriteLine(person.Item2); // Alice
Console.WriteLine(person.Item3); // True

// Fields are accessed only via .Item1, .Item2, etc. — no custom names
// Immutable: you cannot reassign Item1, Item2, etc.
// It's a reference type — allocated on the heap


// ValueTuple — Modern Tuples (C# 7+)
// Inline tuple declaration with named fields
(int Id, string Name, bool IsActive) user = (1, "Alice", true);

Console.WriteLine(user.Id);       // 1
Console.WriteLine(user.Name);     // Alice
Console.WriteLine(user.IsActive); // True

var point = (X: 10, Y: 20);
Console.WriteLine($"X={point.X}, Y={point.Y}"); // X=10, Y=20
*/


//Creation And Initialization
/*
public class TupleDemo
{
    public static void Main()
    {
        // 1. Implicitly typed tuple (The compiler infers (string, int))
        var person = ("Alice", 30); 

        // 2. Explicitly typed tuple
        (string, int) anotherPerson = ("Bob", 25);

        // 3. Tuple with Named Elements (Best Practice)
        // This makes the code readable: no more guessing what Item1 is.
        (string Name, int Age) student = ("Charlie", 21);

        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");


        //Deconstruction -> Allows to unpack tuple values into separate variables for easier access and readability.

        var student = ("Charlie", 21);

        // Unpacking the tuple into two separate variables
        (string name, int age) = student; 

        Console.WriteLine(name); // Output: Charlie
        Console.WriteLine(age);  // Output: 21

        // You can also use 'var' for brevity
        var (userName, userAge) = student;
    }
}
*/



// Returning multiple values from a method using tuples
/*
public class TupleMethodDemo
{
    // Method returning a named tuple
    public static (int sum, int product) Calculate(int a, int b)
    {
        return (a + b, a * b);
    }

    public static void Main()
    {
        // Call the method and capture the tuple
        var result = Calculate(5, 10);
        
        Console.WriteLine($"Sum: {result.sum}");       // Output: 15
        Console.WriteLine($"Product: {result.product}"); // Output: 50

        // OR: Deconstruct the result immediately
        var (s, p) = Calculate(5, 10);
        Console.WriteLine($"Sum: {s}, Product: {p}");
    }
}
*/


//Complete Example
/*
public class TupleFinalDemo
{
    // Function to fetch user data and status
    public static (string Username, bool IsActive, int AccessLevel) GetUserStatus(int id)
    {
        // Simulating a database lookup
        if (id == 1)
        {
            return ("Admin_User", true, 10);
        }
        if (id == 2) return ("Guest_User", true, 1);
        return ("Unknown", false, 0);
    }

    public static void Main()
    {
        // Using a list of tuples
        var usersToCheck = new List<int> { 1, 2, 99 };

        foreach (var id in usersToCheck)
        {
            // Deconstructing the return value directly in the loop
            var (name, active, level) = GetUserStatus(id);
            string status = active ? "Active" : "Inactive";
            Console.WriteLine($"User: {name} | Status: {status} | Level: {level}");
        }
    }
}
*/



//*************************************************** Record ******************************************************//
/*
Introduced in C# 9.0, a record is a special kind of class that is designed primarily for data-centric objects.
Records solve the "Boilerplate" problem of classes. In a standard class, comparing two objects with the same values returns false because they are different instances in memory. Records change this.
Value-Based Equality: Records override Equals() and GetHashCode() automatically.
Non-Destructive Mutation: The with expression creates a shallow copy of the object with specific properties modified.
Init-Only Setters: Properties marked as init can only be set during initialization, ensuring the object remains immutable after creation.
- API Response, Request
- DTO (Data Transfer Object)

Note: Records can have methods, properties, and even implement interfaces, just like classes. 
The main difference is that they come with built-in behavior for immutability and value-based equality, making them ideal for representing data.

public record BankAccount(string AccountNumber, decimal Balance)
{
    // Instead of changing the balance, we return a NEW record with the updated balance
    public BankAccount Deposit(decimal amount)
    {
        return this with { Balance = Balance + amount };
    }
}

// Usage:
var acc = new BankAccount("12345", 100m);
var updatedAcc = acc.Deposit(50m); 

Console.WriteLine(acc.Balance);       // Still 100 (Original is unchanged)
Console.WriteLine(updatedAcc.Balance); // 150 (New object created)

*/


//The most common way to define a record is the Positional Syntax.
/*
using System;

// This one line does the following:
// 1. Creates properties 'FirstName' and 'Age'
// 2. Makes them "init-only" (Immutable)
// 3. Creates a constructor to assign these values
// 4. Implements Value-based equality

public record Person(string FirstName, int Age);

public class PersonOne
{
    public string MiddleName { get; set; }
    public int Level { get; set; }
    public PersonOne(string firstName, int age)
    {
        FirstName = firstName;
        Age = age;
    }
}



public class RecordDemo
{
    public static void Main()
    {
        // Initialize the record
        var person1 = new Person("Alice", 30);

        var personOne = new PersonOne("Alice", 30);
        
        // Printing a record automatically gives a readable string 
        // (Unlike classes, which just print the type name)
        
        Console.WriteLine(person1); 
        Console.WriteLine(personOne); 
        // Output: Person { FirstName = Alice, Age = 30 }
    }
}
*/


//The most critical difference between a class and a record.
/*
using System;

public record UserRecord(string Name, int Id);
public class UserClass { 
    public string Name { get; set; } 
    public int Id { get; set; }
    public UserClass(string name, int id) { Name = name; Id = id; }
}

public class EqualityDemo
{
    public static void Main()
    {
        // --- RECORDS ---
        var record1 = new UserRecord("Bob", 101);
        var record2 = new UserRecord("Bob", 101);

        // Even though they are different objects in memory, 
        // they have the SAME VALUES, so they are EQUAL.
        Console.WriteLine($"Records are equal: {record1 == record2}"); // Output: True

        // --- CLASSES ---
        var class1 = new UserClass("Bob", 101);
        var class2 = new UserClass("Bob", 101);

        // Classes use Reference Equality. 
        // Because they point to different memory addresses, they are NOT equal.
        Console.WriteLine($"Classes are equal: {class1 == class2}"); // Output: False
    }
}
*/


//By default, positional records are immutable (cannot be changed after creation). The properties are init-only.
//To "change" a value in an immutable record, we use the with expression. This does not modify the original object; instead, it creates a new copy with the specified changes. This is called Non-destructive Mutation.
/*
using System;

public record Car(string Brand, string Model, int Year);

public class ImmutableDemo
{
    public static void Main()
    {
        var myCar = new Car("Toyota", "Corolla", 2020);

        //myCar.Year = 2026; // ERROR: Property is init-only!

        // Use 'with' to create a copy with one modified value
        var updatedCar = myCar with { Year = 2026 };

        Console.WriteLine($"Original: {myCar}");      // Year = 2020
        Console.WriteLine($"Updated: {updatedCar}");   // Year = 2026
        
        // The brand and model are copied automatically from myCar
    }
}
*/


/*
//Originally, records were always reference types (like classes). In C# 10, Microsoft introduced record struct.
// This is a value-type record. 
// It combines the performance of a struct with the value-equality of a record.
public record struct Point(int X, int Y);



//Equality Operator On Records vs Classes

public record PersonRecord(string Name, int Age);
public class PersonClass { 
    public string Name { get; set; } 
    public int Age { get; set; }
    public PersonClass(string name, int age) { Name = name; Age = age; }
}

public class EqualityDemo {
    public static void Main() {
        // --- RECORDS ---
        var rec1 = new PersonRecord("Alice", 25);
        var rec2 = new PersonRecord("Alice", 25);

        Console.WriteLine(rec1 == rec2); // TRUE 
        // Why? The compiler checked: 
        // Is "Alice" == "Alice"? Yes. 
        // Is 25 == 25? Yes. 
        // Result: Equal.

        // --- CLASSES ---
        var cls1 = new PersonClass("Alice", 25);
        var cls2 = new PersonClass("Alice", 25);

        Console.WriteLine(cls1 == cls2); // FALSE
        // Why? They are two different objects at two different 
        // memory addresses. The data is ignored.
    }
}
*/

/*
// Class can or cannot inherit record? -> Classes cannot inherit from records, and records cannot inherit from classes.
//inheritace in records -> only record and record
using System;

// Base Record
public record Person(string FirstName, string LastName);

// Derived Record: Inherits from Person
// It takes FirstName and LastName and passes them to the base constructor
public record Employee(string FirstName, string LastName, int EmployeeId, string Department) 
    : Person(FirstName, LastName);

public class InheritanceDemo
{
    public static void Main()
    {
        var person = new Person("John", "Doe");
        var employee = new Employee("John", "Doe", 1234, "IT");

        Console.WriteLine($"Person: {person}");
        Console.WriteLine($"Employee: {employee}");
        
        // Accessing base properties
        Console.WriteLine($"Employee's Last Name: {employee.LastName}"); 
    }
}
*/

/*
//Full Example: Using Records in a Bank System
using System;
using System.Collections.Generic;

// Use a record for the Transaction: it should never change once created
public record Transaction(string Id, decimal Amount, DateTime Date, string Description);

// Use a record for User Account state
public record AccountState(string AccountHolder, decimal Balance);

public class BankSystem
{
    public static void Main()
    {
        // Initial state
        var account = new AccountState("John Doe", 1000.00m);
        
        // List to store transaction history
        var history = new List<Transaction>();

        // Simulate a deposit
        var deposit = new Transaction("T1", 200.00m, DateTime.Now, "Salary Deposit");
        history.Add(deposit);

        // Update account state using 'with' (Immutable update)
        account = account with { Balance = account.Balance + deposit.Amount };

        // Simulate a withdrawal
        var withdraw = new Transaction("T2", 50.00m, DateTime.Now, "ATM Withdrawal");
        history.Add(withdraw);
        
        account = account with { Balance = account.Balance - withdraw.Amount };

        Console.WriteLine($"Account Holder: {account.AccountHolder}");
        Console.WriteLine($"Final Balance: ${account.Balance}");
        Console.WriteLine("\nTransaction History:");
        foreach(var t in history)
        {
            Console.WriteLine($"{t.Date}: {t.Description} | {t.Amount}");
        }
    }
}
*/





//*************************************************** Delegates ******************************************************//
//A delegate is a "Function Pointer." It allows you to pass a method as a parameter to another method.
//To use a delegate, you need three steps: Declaration, Instantiation, and Invocation.
/*
using System;

public class DelegateDemo {
    // 1. DECLARATION: Define the "signature" of the methods this delegate can hold.
    // This delegate can point to any method that takes a string and returns void.
    public delegate void MyDelegate(string message);

    public static void Main() {
        // 2. INSTANTIATION: Point the delegate to a specific method.
        MyDelegate del = WriteToConsole;

        // 3. INVOCATION: Call the delegate as if it were a method.
        del("Hello from the delegate!"); 
    }

    // A method that matches the delegate signature
    public static void WriteToConsole(string text) {
        Console.WriteLine($"Console says: {text}");
    }
}
*/


//A delegate can hold multiple methods at once. 
//When the delegate is invoked, all attached methods are called in the order they were added.
/*
Note: Delegate is a strict contract. You can only attach methods that match its signature (parameters and return type).
If you define a delegate as Notify(string message), every single method you attach to it must match that exact signature (it must take exactly one string and return void).
*/
/*
using System;
using System.Runtime.CompilerServices;

public class MulticastDemo {
    public delegate void Notify(); // Signature: no params, no return

    public static void Main() {
        Notify notifyHandler = SendEmail;
        notifyHandler += SendSMS;   // Adding another method using +=
        notifyHandler += LogToFile;  // Adding another

        Console.WriteLine("Firing all notifications...");
        notifyHandler(); // Calls all three methods!

        // Removing a method using -=
        notifyHandler -= SendSMS;
        Console.WriteLine("\nFiring after removing SMS...");
        notifyHandler(); 
    }

    public static void SendEmail() {
        Console.WriteLine("Email sent!");
    }
    public static void SendSMS(string message) => Console.WriteLine($"SMS sent! {message}");
    public static void LogToFile() => Console.WriteLine("Logged to file!");
}
*/


/*
//Built in delegates in C#:
//Action<T>	For methods that return void.	void Method(T arg)
//Func<T, TResult>	For methods that return a value.	TResult Method(T arg)
//Predicate<T>	For methods that return a boolean.	bool Method(T arg)

using System;

public class BuiltInDelegates {
    public static void Main() {
        // Action: Takes a string, returns void
        Action<string> greet = (name) => Console.WriteLine($"Hello {name}!");
        greet("Alice");

        // Func: Takes two ints, returns an int
        Func<int, int, int> add = (a, b) => a + b;
        int result = add(5, 10); // result = 15
        Console.WriteLine($"Sum: {result}");

        // Predicate: Takes an int, returns bool (used for filtering)
        Predicate<int> isEven = (n) => n % 2 == 0;
        Console.WriteLine($"Is 4 even? {isEven(4)}"); // True
    }
}
*/
//Use Cases To be Inserted


//*************************************************** Events ******************************************************//
//An Event is a wrapper around a delegate. It implements the Publisher-Subscriber Pattern.
/*
using System;

public class Boiler {
    // 1. Define the delegate (the contract)
    public delegate void OverheatHandler();

    // 2. Define the event based on that delegate
    public event OverheatHandler OverheatOccurred;

    public void HeatUp(int temperature) {
        Console.WriteLine($"Temperature is {temperature}°C");
        if (temperature > 100) {
            // 3. Trigger the event (Check for null first!)
            OverheatOccurred?.Invoke(); 
        }
    }
}

public class Program {
    public static void Main() {
        Boiler myBoiler = new Boiler();

        // Subscribe to the event
        myBoiler.OverheatOccurred += SoundAlarm;
        myBoiler.OverheatOccurred += TurnOnCooling;

        myBoiler.HeatUp(110); // This will trigger both methods
    }

    static void SoundAlarm() => Console.WriteLine("ALARM! Boiler overheating!");
    static void TurnOnCooling() => Console.WriteLine("Cooling system activated!");
}
*/


/*
//Exact way Event is used today
//In real-world .NET development, we don't usually define custom delegates for events. We use the built-in EventHandler and EventArgs classes. This allows us to pass data along with the event.

using System;

// 1. PROFESSIONAL STANDARD: Use a custom EventArgs class to carry data.
// Even if you only need one value (temperature), this allows you to 
// add more data later without breaking the rest of your code.
public class BoilerOverheatEventArgs : EventArgs 
{
    public int Temperature { get; }
    public DateTime TimeOfOverheat { get; }

    public BoilerOverheatEventArgs(int temp) 
    {
        Temperature = temp;
        TimeOfOverheat = DateTime.Now;
    }
}

public class Boiler 
{
    // 2. PROFESSIONAL STANDARD: Use EventHandler<T> instead of a custom delegate.
    // This removes the need for: 'public delegate void OverheatHandler()'
    public event EventHandler<BoilerOverheatEventArgs> OverheatOccurred;

    public void HeatUp(int temperature) 
    {
        Console.WriteLine($"Temperature is {temperature}°C");
        
        if (temperature > 100) 
        {
            // 3. PROFESSIONAL STANDARD: Do not call the event directly here.
            // Call the specialized "OnEvent" method.
            OnOverheatOccurred(new BoilerOverheatEventArgs(temperature));
        }
    }

    // 4. PROFESSIONAL STANDARD: The "OnEvent" pattern.
    // This is 'protected virtual' so that if a class inherits from Boiler, 
    // it can override how the event is triggered.
    protected virtual void OnOverheatOccurred(BoilerOverheatEventArgs e) 
    {
        // The ?. syntax ensures we don't crash if no one is subscribed.
        // 'this' tells the subscriber WHICH boiler is overheating.
        OverheatOccurred?.Invoke(this, e);
    }
}

public class Program 
{
    public static void Main() 
    {
        Boiler myBoiler = new Boiler();

        // Subscribe to the event
        myBoiler.OverheatOccurred += SoundAlarm;
        myBoiler.OverheatOccurred += TurnOnCooling;

        myBoiler.HeatUp(110); 
    }

    // 5. PROFESSIONAL STANDARD: Event handlers must match the signature:
    // (object sender, TEventArgs e)
    static void SoundAlarm(object sender, BoilerOverheatEventArgs e) 
    {
        Console.WriteLine($"ALARM! Boiler overheated to {e.Temperature}°C at {e.TimeOfOverheat}!");
    }

    static void TurnOnCooling(object sender, BoilerOverheatEventArgs e) 
    {
        Console.WriteLine($"Cooling system activated for temperature {e.Temperature}°C.");
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
1. Create a readonly struct Transaction (containing Amount and Id) and a class Account (containing Balance and a List<Transaction>) to manage immutable payment records and stateful accounts.
2. Implement a method AnalyzeAccount in the Account class that returns a named tuple (decimal TotalSpent, decimal MaxTransaction) by calculating the sum and peak of all transactions.
3. Create a "Tax Engine" method that accepts a decimal amount and an array of Func<decimal, decimal> (strategies), applying each tax/discount function sequentially to the total.
4. Define a PaymentFailed delegate and use it to create a multicast event that triggers three separate notification methods (Email, SMS, and System Log) whenever a transaction is rejected.
5. Implement a generic method ProcessWithRetry<T> that takes an Action<T> (the payment logic) and a Func<bool> (the condition); it should execute the action repeatedly until the condition returns true or a max retry limit is hit.
*/