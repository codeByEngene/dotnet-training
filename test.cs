//************************************************************* Exception Types ******************************************************//
/*
    --Developer Exceptions
    1. NullReferenceException : This is the most common and notorious error. It means you tried to use a variable or object that doesn't exist 
    string username = null;
    int length = username.Length;

    2. DivideByZeroException : The simplest math error. You attempt to divide a number by zero.
    3. ArgumentOutOfRangeException : You passed an argument that is valid in type (it's an integer, for instance), but its value is outside the acceptable range. Age value in negative
    4. FormatException : You are trying to convert data from one type to another (e.g., String to Integer), but the data format is incorrect.
    int number = int.Parse("hello"); 

    5. ArgumentException : A general error that happens when an argument is fundamentally wrong, usually concerning required information (e.g., a required name field was left blank).

    --System and Runtime Exceptions
    6. FileNotFoundException : The program asks the operating system for a file, and the operating system replies: "I don't know that file.". You hardcoded a path to a file that has been moved, renamed, or never existed.
    7. IOException : This is a general umbrella error for any I/O (Input/Output) issue. It's used when the operating system or hardware messes up. You try to write a file, but the folder is read-only. (Permissions error). You are reading from a network source, and the network cable gets unplugged.

*/



//************************************************************* Exception Handling ******************************************************//
// Keyword	Action	Purpose
// try	Executes code.	Contains the risky code block.
// catch	Handles the error.	Defines what to do if a specific error occurs.
// finally	Cleanup code.	Code that runs no matter what happens (Always close resources!).
// throw	Manually triggers an error.	Used when your logic determines an invalid state.

/*
public class Program
{
    // This method simulates an action that must always clean up its resources.
    public static void RunProcessing(string scenarioName, int numerator, int denominator)
    {
        // 💡 Concept: This string simulates a resource we are using (like a file or a database connection).
        string resourceStatus = "System connection established (We're ready to go!)"; 
        
        Console.WriteLine("\n===========================================================");
        Console.WriteLine($"\nRunning Scenario: {scenarioName}");
        Console.WriteLine($"  (Status: {resourceStatus})");
        Console.WriteLine("---------------------------------------------------------");


        // 1. THE TRY: The "Hopeful" Block
        try
        {
            Console.Write("  (Action: Trying to divide numbers...)");

            // The risky code goes here. We are hoping this line succeeds.
            int result = numerator / denominator;

            // If we get here, it means everything was fine!
            Console.WriteLine($" SUCCESS! The result is: {result}");
        }
        catch (DivideByZeroException ex)
        {
            // 2. THE CATCH: The "Oh no, but it's okay" Block
            // This code only runs IF the error was exactly a DivideByZeroException.
            Console.WriteLine(" FAILED! (Got caught): Uh oh! We can't divide by zero—that's mathematically impossible. Let's report that instead.");
            // Execution jumps here and skips the rest of the 'try' block.
        }
        catch (Exception ex)
        {
            // 2. THE CATCH: The Safety Net. 
            // This is our general fallback for any other weird, unexpected error.
            Console.WriteLine($" FAILED! (Got caught): Whoops. We hit a completely unexpected error. Error: {ex.Message}");
        }
        finally
        {
            // 3. THE FINALLY: The "Cleanup Crew"
            // This MUST run. No matter if it succeeded, failed, or was interrupted,
            // we MUST do cleanup here (close files, release locks, etc.).
            Console.WriteLine("\n  [FINALLY]: Cleanup finished. Resources released. (The process finished neatly.)");
        }
    }

    public static void Main(string[] args)
    {
        // --- SCENARIO 1: Everything Works Perfectly ---
        // The code runs the TRY block, then skips CATCH, and finishes with FINALLY.
        RunProcessing("SUCCESS: The numbers work fine (10 / 2)", 10, 2);


        // --- SCENARIO 2: The Predicted Failure ---
        // The code FAILS in TRY, jumps immediately to the specific CATCH, and then runs FINALLY.
        RunProcessing("FAILURE: Division by zero", 10, 0);


        // --- SCENARIO 3: Another Clean Run ---
        // The code shows that even after a failure, the program can continue gracefully.
        RunProcessing("SUCCESS: Another routine task (100 / 5)", 100, 5);
    }
}
*/


//************************************************************* Polymorphism ******************************************************//

/*
What is Polymorphism? (Meaning: "Many Forms")
Polymorphism means: "One single command can trigger different actions depending on the type of object it's given."

Imagine you are the pet owner, and you give the command: "Make a Sound!"

If you point at the Dog, it hears "Make a Sound!" and responds by BARKING.
If you point at the Cat, it hears "Make a Sound!" and responds by MEOWING.
If you point at the Cow, it hears "Make a Sound!" and responds by MOOING.
The Key Insight: You, the owner, only need one command (MakeSound()). You don't need to know how every animal makes noise. You just need to know that all of them can fulfill the general command "Make Sound!"

Polymorphism is the ability to write code that treats all objects the same way (using one common interface) while letting the object itself decide what specific action to perform.
*/
// Inheritance with base class and derived classes  and polymorphism



/*
using System;
// BASE CLASS
class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    // Constructor: initialises the common data
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    // 'virtual' means child classes are ALLOWED to override this method
    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} makes a generic sound.");
    }
    // Non-virtual: child classes CANNOT override this
    public void Breathe()
    {
        Console.WriteLine($"{Name} is breathing.");
    }
}
//  DERIVED CLASS: Dog
class Dog : Animal // ':' means 'inherits from'
{
    public string Breed { get; set; } // Dog-specific property // 'base(name, age)' calls the Animal constructor to set shared data
    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed; // set Dog-specific data
    }
    // 'override' replaces Animal's MakeSound with Dog-specific behaviour
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} ({Breed}) says: Woof! Woof!");
    }
    // Dog-specific method — not in Animal
    public void Fetch(string item)
    {
        Console.WriteLine($"{Name} fetches the {item}!");
    }
}
//  DERIVED CLASS: Bird
class Bird : Animal
{
    public double WingSpan { get; set; }
    public Bird(string name, int age, double wingSpan) : base(name, age)
    {
        WingSpan = wingSpan;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} chirps: Tweet tweet!");
    }
    public void Fly() => Console.WriteLine($"{Name} is flying with {WingSpan}cm wingspan.");
}
//  Main
class Program
{
    static void Main()
    {
        Dog d = new Dog("Rex", 3, "Labrador");
        Bird b = new Bird("Tweety", 1, 25.5);
        d.MakeSound(); // Rex (Labrador) says: Woof! Woof! ← overridden
        b.MakeSound(); // Tweety chirps: Tweet tweet! ← overridden
        d.Breathe(); // Rex is breathing. ← inherited, not
        
        d.Fetch("ball");// Rex fetches the ball! ← Dog-specific
        b.Fly(); // Tweety is flying... ← Bird-specific
                 // 'base' keyword in derived class calls the parent version
                 // e.g., inside Dog.MakeSound() you could write base.MakeSound()
                 // to run Animal's version before your Dog-specific code
    }
}
*/





//************************************************************* Abstract Class ******************************************************//
// A Blueprint for Blueprints: It's a base class that cannot be instantiated (you cannot create an object from it).
// Enforcement: Its primary job is to enforce a minimum standard. It says, "If you want to be a type of Vehicle, you must have these features and must implement these methods."
// The Key Rule (The Golden Rule)
// If you create a class that inherits from an abstract class, you must provide a concrete implementation for every abstract method defined in the parent class.


using System;

// THE ABSTRACT CLASS (The Master Blueprint)
// 'abstract' means this class is just a template; you cannot create a real object from it.
/*
public abstract class Vehicle
{
    // Common data shared by all vehicles
    public int MaxSpeed { get; protected set; }
    
    // ⚙️ Abstract Method: This method has NO code in the abstract class.
    // It just promises that any child class MUST write its own version of this.
    public abstract void StartEngine();

    // We can also include concrete methods (methods with working code).
    public void DisplayWheels()
    {
        Console.WriteLine("This vehicle has wheels.");
    }
}

// 2. THE CONCRETE CLASS (The Specific Product)
// The Truck must inherit the rules of the Vehicle blueprint.
public class Truck : Vehicle
{
    public int LoadCapacity { get; set; }

    public Truck(int maxSpeed, int capacity)
    {
        // Must initialize the required properties from the blueprint.
        MaxSpeed = maxSpeed;
        LoadCapacity = capacity;
    }

    // REQUIRED IMPLEMENTATION: We must fulfill the contract defined by the abstract class.
    public override void StartEngine()
    {
        // This is the Truck's unique method of starting up.
        Console.WriteLine("VROOOM! The powerful diesel engine roars to life.");
    }
}

// 3. ANOTHER CONCRETE CLASS (A different specific product)
public class SportsCar : Vehicle
{
    public int Wheelbase { get; set; }

    public SportsCar(int maxSpeed, int wheelbase)
    {
        MaxSpeed = maxSpeed;
        Wheelbase = wheelbase;
    }
    
    // REQUIRED IMPLEMENTATION: Fulfilling the contract again.
    public override void StartEngine()
    {
        // This is the Sports Car's unique method of starting up.
        Console.WriteLine("VZZZ! The tiny motor screams to life.");
    }
}


// ==================== Execution ======================================
public class Program
{
    public static void Main(string[] args)
    {
        // ATTEMPT 1: Trying to make an object from the abstract class.
        // This will fail at compile time! We cannot do this.
        // Vehicle genericVehicle = new Vehicle(); // Compiler Error!

        // RUN 1: Using the Truck Blueprint
        // We create a specific object, but it adheres to the general Vehicle rules.
        Truck myTruck = new Truck(maxSpeed: 120, capacity: 1000);
        
        Console.WriteLine("--- Truck Object Created ---");
        myTruck.DisplayWheels();  // Uses the common blueprint method
        myTruck.StartEngine();   // Calls the Truck's specific engine start (overrides the abstract method)

        // RUN 2: Using the Sports Car Blueprint
        SportsCar myCar = new SportsCar(maxSpeed: 200, wheelbase: 2800);
        
        Console.WriteLine("\n--- Sports Car Object Created ---");
        // Even though it's a different object, it was forced to follow the rules.
        myCar.DisplayWheels(); 
        myCar.StartEngine(); // Calls the SportsCar's specific engine start.
    }
}
*/





//************************************************************* Interface ******************************************************//
// An Interface is a pure contract—a list of promises. It is the ultimate definition of "must be able to do this."
// It tells a class: "If you want to claim you are a 'Flyer,' you MUST have these specific skills."
// The key thing about an Interface is that it defines behavior, not identity.


// The Contract: IAmAWorker
/*
public interface IWorker
{
    // We only list the promise: every class implementing this must have this method.
    void AcquireTools();
    void MeasureMaterials();
    void ShowUpOnTime();
}

// The Concrete Class: The Painter
public class Painter : IWorker
{
    // We MUST implement all the required methods from the contract.
    public void AcquireTools() {  Painter-specific tool logic  }
    public void MeasureMaterials() {  Painter-specific measurement logic  }
    public void ShowUpOnTime() {  Painter-specific logic }
}
*/