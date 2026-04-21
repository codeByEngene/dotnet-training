//************************************ How C# Programs Work ************************************//
/*
1. Source Code -> .cs files
2. Compilation -> .exe or .dll (Intermediate Language - IL)
3. CLR (Common Language Runtime) -> manages memory, handles exceptions, garbage collection
4. JIT (Just-In-Time Compiler) -> compiles IL to machine code at runtime
*/

//************************************ Step Wise Program Execution ************************************//
/*
Step 1 — You write code (.cs file)
Think of this like writing a recipe. You type instructions in English-like text (C#), and save it as a file. 
The computer can't do anything with this yet — it's just words on a page.

Step 2 — The compiler translates it (IL code)
A tool called the compiler reads your recipe and converts it into a special intermediate language (IL). 
It's no longer human-readable, but it's also not yet something your computer's processor can run directly. Think of it like translating your recipe into a universal symbol language.

Step 3 — The CLR manages things
The Common Language Runtime is like a kitchen manager. When your program runs, the CLR watches over it — 
it cleans up memory you no longer need (garbage collection), catches errors so your app doesn't crash badly, and keeps everything running safely.
mark and sweep algorithm: The GC periodically scans the memory to find objects that are no longer referenced by the application. It marks those objects and then sweeps through the memory to free up the space they occupied.


Step 4 — The JIT makes it fast
The Just-In-Time compiler is the chef who actually cooks. It reads those symbols and converts them into real instructions that your specific computer's processor understands — right as the program is running.

Step 5 — Your program runs!
The machine instructions execute, and your app does its thing — shows a window, calculates something, plays a sound, etc.
*/


//************************************ Access Modifiers ************************************//
/*
public -> any where accessible -> shopping mall open doors
private -> only inside same class -> shopping mall manager's office
protected -> inside same class and derived classes -> shopping mall manager's office and security guard (derived class)
internal -> inside same assembly , same project -> shopping mall, only people with access card can enter
protected internal -> same class, chil class, or any class within same assembly/project -> shopping mall, only people with access card can enter, and security guard (derived class)
private protected -> inside same class and derived classes (but not accessible from outside) -> shopping mall manager's office, only security guard (derived class) can enter, but not accessible from outside
*/



//************************************ Classes And Objects ************************************//
/*
Class -> blueprint for creating objects, defines properties and behaviors
Object -> instance of a class, has state and behavior
*/
//************************************ Class Syntax ************************************//
/*
class ClassName
{
    // Fields (variables)
    // Properties
    // Methods (functions)
    // Constructors
}
*/

/*
    Example:
    // This is the CLASS — the blueprint (written once)
    class Car
    {
        // Properties — the data each car holds
        public string Color;
        public string Brand;
        public int Speed;

        // Method — something every car can do
        public void Honk()
        {
            Console.WriteLine("Beep beep!");
        }
    }
*/


//************************************ Object Syntax ************************************//
/*
    ClassName objectName = new ClassName(); // Create a new object (instance of the class)
    objectName.Property = value; // Set properties
*/

/*
    Example:
    // This is the OBJECT — an actual car you can use (created from the blueprint)
    Car myCar = new Car(); // Create a new car object
    myCar.Color = "Red"; // Set properties
    myCar.Brand = "Toyota";
    myCar.Speed = 100;
    myCar.Honk(); // Call method
*/


//************************************ Constructors ************************************//
/*
Constructor -> special method that is called when an object is created, used to initialize properties
Syntax:
class ClassName
{
    // Constructor
    public ClassName()
    {
        // Initialization code
    }
}       
*/

//************************************ Constructors Syntax ************************************//
/*
class ClassName
{
    // Constructor
    public ClassName()
    {
        // Initialization code
    }
}       
*/

/*
    Example:
    class Car
    {
        public string Color;
        public string Brand;
        public int Speed;
        public int NoOfDoors;

        // Constructor to initialize properties
        public Car(string color, string brand, int speed)
        {
            Color = color;
            Brand = brand;
            Speed = speed;
            NoOfDoors = 4; // Default value for all cars
        }

        public void Honk()
        {
            Console.WriteLine("Beep beep!");
        }
    }

    // Creating an object using the constructor
    Car myCar = new Car("Red", "Toyota", 100);
    myCar.Honk();
*/



//************************************ Static Class ************************************//
/*
Static Class -> a class that cannot be instantiated, all members must be static, used for utility or helper methods
*/

//************************************ Static Class Syntax************************************//
/*
static class ClassName
{
    // Static members
}

//Usage:
ClassName.StaticMethod(); // Call static method without creating an object
*/

/*
    Example:
    static class Utility
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Using the static method without creating an object
    Utility.PrintMessage("Hello, World!");
*/


//************************************ Complete Example With All The Learned Details ************************************//

/*
namespace Day5Session
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            
            //Access Modifiers Example:
            //student.name = "Ram"; // Error: 'Student.name' is inaccessible due to its protection level
            //student.age = 20; // Error: 'Student.age' is inaccessible due to its protection level
            //student.college = "XYZ College"; // Accessible (internal)
            //student.country = "USA"; // Accessible (protected internal)
            
            

            // Set student details using the method
            //if we don't set student details, it will use the default values from the constructor
            student.SetStudentDetails("Ram", 20); 
            
            // Display student details
            student.DisplayStudent(); 
        
            //Usage of derived class / inheritance
            SunwayStudents sunwayStudents = new SunwayStudents();
            sunwayStudents.DisplayStudentDetails();
            sunwayStudents.DisplayStudent();


            //Usage of static class and method
            Utility.PrintMessage("Welcome to the Student Management System!");
        
            Console.ReadLine();

            // Reference Type Example:
            Student studentSunway = student; // Reference to the same object
            studentSunway.SetStudentDetails("Shyam", 20); // Both student and studentSunway refer to the same object, so changes affect both
            // Display student details using both references
            student.DisplayStudent();
            // Display student details using the second reference
            studentSunway.DisplayStudent();
            

        }
    }

    public class Student
    {
        // Fields with different access modifiers

        // Proper way to initialize properties with getters and setters

        // can be accessed only within the Student class
        private string name { get; set; }

        // can be accessed within the Student class and derived classes (like SunwayStudents)
        protected int age;

        // can be accessed within the same assembly/project (like Program class)
        internal string college = "Sunway College";

        // can be accessed within the same assembly/project and derived classes (like SunwayStudents)
        protected internal string country = "Nepal";

        // constructor to initialize default values for the student
        public Student()
        {
            name = "Hello Bob";
            age = 10;
        }

        // Method to set student details
        public void SetStudentDetails(string studentName, int studentAge)
        {
            name = studentName;
            age = studentAge;
        }

        // Method to display student details
        public void DisplayStudent()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("College: " + college);
            Console.WriteLine("Country: " + country);
        }
    }

    // Derived class that inherits from Student class
    public class SunwayStudents : Student
    {
        public void DisplayStudentDetails()
        {
            Console.WriteLine("College: " + college); // Accessible (internal)
            Console.WriteLine("Country: " + country); // Accessible (protected internal)
            Console.WriteLine("Age: " + age); // Accessible (protected)
        }
    }

    // Static class for utility methods
    // This class cannot be instantiated and all members must be static
    public static class Utility
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
*/

//************************************ Notes ************************************//
/*
    1. Inherited class after initialization will also hit the constructor of the base class (Student) and initialize the default values for the inherited class (SunwayStudents) as well, but we can override it in the derived class if needed.
    2. Static classes cannot be instantiated, and all members must be static. They are used for utility or helper methods that don't require an instance of the class to be used.
    3. Static class can have constructors, but they are static constructors and are called automatically before the first instance is created or any static members are referenced. They are used to initialize static members of the class.
*/



//************************************ Practice Session ************************************//

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
// 1. Create a 'Rectangle' class with private fields Width and Height, a parameterised constructor, public properties with validation (no negative values), and methods GetArea() and GetPerimeter().
// Solution:
/*
public class Rectangle
{
    private double _width;
    private double _height;

    // public double Width
    // {
    //     get { return _width; } // This is what happens when we READ the width.
    //     set { _width = value; } // This is what happens when we WRITE/SET the width.
    // }

    // Public properties with validation (Ensures no negative dimensions)
    public double Width
    {
        get => _width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Width), "Width cannot be negative.");
            }
            _width = value;
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Height), "Height cannot be negative.");
            }
            _height = value;
        }
    }

    // Parameterized constructor
    public Rectangle(double width, double height)
    {
        // Use the setters to automatically trigger validation
        this.Width = width;
        this.Height = height;
        Console.WriteLine($"\nRectangle Created: {width}x{height}");
    }

    // Method to calculate the area
    public double GetArea()
    {
        return Width * Height;
    }

    // Method to calculate the perimeter
    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}
*/


// 2. Create a 'Person' class with Name, Age, Email. The Email property must validate that it contains '@'. If invalid, throw an exception.
// 3. Add a static field 'TotalObjects' to your Person class. Every time a Person is created, increment it. After creating 5 people, print the total count.
// Solution:
/*
public class Person
{
    public static int TotalObjects { get; private set; } = 0;
    public string Name { get; set; }
    public int Age { get; set; }
    private string Email { get; set; } 

    // Constructor: Runs when a new Person is created.
    public Person(string name, int age, string email)
    {       
        TotalObjects++;  
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Person name cannot be empty.");
        }
            
        if (age < 0)
            throw new ArgumentOutOfRangeException(nameof(Age), "Age must be zero or positive.");

        // Check if the email string contains the '@' symbol.
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new FormatException("Error: The email must be a valid format (it needs '@').");
        }

        Name = name;
        Age = age;
        Email = email;
        Console.WriteLine($"Person Successfully created: {Name}");
    }
}
*/


// 4. Create a 'Temperature' class that stores Celsius internally but has a computed property 'Fahrenheit' that converts it: F = (C × 9/5) + 32.
// Solution:
/*
public class Temperature
{
    private double Celsius { get; set; }

    // Constructor
    public Temperature(double celsius)
    {
        // Simple input check
        if (celsius < -273.15) 
            throw new ArgumentException("Temperature is too cold (below absolute zero).");
            
        Celsius = celsius;
        Console.WriteLine($"\n Temperature Set to {celsius}°C.");
    }
    public double Fahrenheit()
    {
        return (Celsius * 9 / 5) + 32;        
    }
}
*/

//Complete Program
/*
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n*********************************************************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("******************  1. Rectangle ************************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("*********************************************************\n");
        var rectangle = new Rectangle(10.0, 5.0);
        Console.WriteLine($"Area: {rectangle.GetArea()}");
        Console.WriteLine($"Perimeter: {rectangle.GetPerimeter()}");
        Console.WriteLine("\n--- Trying to create a rectangle with negative width ---");
        try
        {
            var invalidBox = new Rectangle(-5.0, 10.0);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: Successfully blocked invalid input. Reason: {e.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n*********************************************************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("******************  2. & 3. Person **********************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("*********************************************************\n");
        Person personOne    = new Person("Alice", 30, "alice@example.com");
        Person personTwo    = new Person("Bob", 25, "bob@work.net");
        Person personThree  = new Person("Charlie", 40, "charlie@home.org");
        Person personFour   = new Person("Diana", 22, "diana@test.edu");
        Person personFive   = new Person("Edward", 50, "edward@corporate.biz");

        Console.WriteLine($"\nTotal number of people created (Static Count): {Person.TotalObjects}");
        Console.WriteLine("\nTrying to create a person with invalid email ---");
        try
        {
            Person p6 = new Person("Frank", 35, "franknodotcom"); 
        }
        catch (FormatException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: Validation successfully failed. Reason: {e.Message}");
            Console.ResetColor();
        }
        

        Console.WriteLine("\n*********************************************************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("******************  4. Temperature **********************");
        Console.WriteLine("*********************************************************");
        Console.WriteLine("*********************************************************\n");
        // Example 1: Freezing point (0°C)
        var freezingPoint = new Temperature(0.0);
        // We don't set a property; we just read the computed value.
        Console.WriteLine($"The Fahrenheit temperature is: {freezingPoint.Fahrenheit():F2}°F"); 

        // Example 2: Boiling point (100°C)
        var boilingPoint = new Temperature(100.0);
        Console.WriteLine($"The Fahrenheit temperature is: {boilingPoint.Fahrenheit():F2}°F"); 
        
        // Example 3: Crossover point (-40°C)
        var crossoverPoint = new Temperature(-40.0);
        Console.WriteLine($"The Fahrenheit temperature is: {crossoverPoint.Fahrenheit()}°F");
    }
}
*/