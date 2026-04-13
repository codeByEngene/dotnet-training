/*
1. Methods (Parameters, Return Types, Overloading)
2. Recursion
*/

//************************************ Methods and Parameters ************************************//
//************************************ Methods Syntax ********************************************//
/*
access_modifier return_type method_name(data_type parameter_name)
{
    //method body
}
return_type -> data_type, void
*/

//************************************ Method With Parameters and Return Type **********************************************//


//************************************ Method Declaration and Definition and Invocation ************************************//
/*
int AddTwoNumbers(int a, int b)
{
    return a + b;
}

int result = AddTwoNumbers(5, 10);
Console.WriteLine(result); // Output: 15
*/

//************************************ Method Without Return Type (void) ************************************//
/*
void Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

Greet("Alice"); // Output: Hello, Alice!
*/

//************************************ Paramterless Method ************************************//
/*
void Greet()
{
    Console.WriteLine($"Hello!");
}

Greet(); // Output: Hello!
*/


//************************************ Method Overloading ************************************//
// Method overloading allows you to have multiple methods with the same name but different parameters (different type, number, or order of parameters).
/*
Maths maths = new Maths();
maths.Greetings();
maths.Greetings("Alice");
maths.Greetings("Bob", "Kathmandu");

public class Maths
{
    public void Greetings()
    {
        Console.WriteLine("Hello Stranger!");
    }

    public void Greetings(string name)
    {
        Console.WriteLine($"Hello {name}!");
    }
    
    //default value in parameters
    public void GreetingsWorld(string world = "hello!")
    {
        Console.WriteLine($"Hello {world}!");
    }

    public void Greetings(string name, string address)
    {
        Console.WriteLine($"Hello {name} from {address}!");
    }
}
*/


//************************************ Recursion ************************************//
// Recursion is a programming technique where a function calls itself in order to solve a problem. A recursive function typically has two main components: 
// a base case that stops the recursion, and a recursive case that breaks the problem into smaller subproblems and calls itself with those subproblems.
/*
Maths maths = new Maths();
long factorialValue = maths.Factorial(5);
Console.WriteLine(factorialValue);
//5! = 5 * 4 * 3 * 2 * 1

public class Maths
{
    public long Factorial(int n)
    {
        if (n<=1)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }
}
*/


//************************************ Ref And Out Parameters ************************************
// ref and out are used to pass parameters by reference, allowing the method to modify the value of the parameter and have that change reflected outside the method. 
// The main difference between ref and out is that ref requires the variable to be initialized before it is passed to the method, while out does not require initialization and must be assigned a value within the method before it returns.
/*
Maths maths = new Maths();
int passByValue = 0;
maths.AddTwoNumbersPassByValue(5, 10, out passByValue);
Console.WriteLine(passByValue);

int passByRef = 6;
maths.AddTwoNumbersPassByReference(5, 10, ref passByRef);
Console.WriteLine(passByRef);
//5! = 5 * 4 * 3 * 2 * 1

public class Maths
{ 
    public void AddTwoNumbersPassByValue(int a, int b, out int passByValue)
    {
        passByValue = a + b;
    }
    
    public void AddTwoNumbersPassByReference(int a, int b, ref int passByRef)
    {
        passByRef += a + b;
    }   
}
*/