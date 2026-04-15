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
//1.⁠ ⁠Write a method 'int Square(int n)' that returns n squared. Call it from Main.
// Solution:
/*
public int Square(int n)
{
    return n * n;
}
*/


//2.⁠ ⁠Write an overloaded method 'string Describe(int n)' and 'string Describe(double n)' — each returns a sentence describing the number.
// Solution:
/*
// Overload for integer input
public string Describe(int n)
{
    return $"Integer {n} is a whole number found on the number line.";
}

// Overload for double input
public string Describe(double n)
{
    return $"Double {n} represents a number that can have fractional parts.";
}
*/


//3.⁠ ⁠Write a recursive method 'int SumUpTo(int n)' that returns the sum of all numbers from 1 to n. Verify: SumUpTo(5) = 15.
// Solution:
/*
public int SumUpTo(int n)
{
    // Base Case: If n is 0 or less, the sum is 0.
    if (n <= 0)
    {
        return 0;
    }
    // Recursive Step: SumUpTo(n) = n + SumUpTo(n-1)
    return n + SumUpTo(n - 1);
}
*/


//4.⁠ ⁠Write a method that takes a string and uses a for loop to count how many vowels (a, e, i, o, u) it contains. Return that count.
// Solution:
/*
public static int CountVowels(string text)
{
    if (string.IsNullOrEmpty(text))
    {
        return 0;
    }

    int count = 0;
    // Convert the string to lowercase to handle both 'A' and 'a' easily
    string lowerText = text.ToLower();

    // Use a for loop to iterate through each character
    for (int i = 0; i < lowerText.Length; i++)
    {
        char currentChar = lowerText[i];

        // Check if the character is one of the vowels
        if (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' || currentChar == 'o' || currentChar == 'u')
        {
            count++;
        }
    }
    return count;
}
*/

//Complete Program
/*
public class DayFourPracticeSession
{
    public int Square(int n)
    {
        return n * n;
    }

    // Overload for integer input
    public string Describe(int n)
    {
        return $"Integer {n} is a whole number found on the number line.";
    }

    // Overload for double input
    public string Describe(double n)
    {
        return $"Double {n} represents a number that can have fractional parts.";
    }

    public int SumUpTo(int n)
    {
        // Base Case: If n is 0 or less, the sum is 0.
        if (n <= 0)
        {
            return 0;
        }
        // Recursive Step: SumUpTo(n) = n + SumUpTo(n-1)
        return n + SumUpTo(n - 1);
    }

    public int CountVowels(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        int count = 0;
        // Convert the string to lowercase to handle both 'A' and 'a' easily
        string lowerText = text.ToLower();

        // Use a for loop to iterate through each character
        for (int i = 0; i < lowerText.Length; i++)
        {
            char currentChar = lowerText[i];

            // Check if the character is one of the vowels
            if (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' || currentChar == 'o' || currentChar == 'u')
            {
                count++;
            }
        }
        return count;
    }
    public void Main(string[] args)
    {
        // --- 1. Test Square Method ---
        int num1 = 7;
        int resultSquare = Square(num1);
        Console.WriteLine("\n[1. Square Method]");
        Console.WriteLine($"The square of {num1} is: {resultSquare}");

        // --- 2. Test Overloading ---
        Console.WriteLine("\n[2. Overloaded Describe Method]");
        int intNum = 42;
        double doubleNum = 3.14159;
        
        // Calling the int overload
        string descInt = Describe(intNum);
        Console.WriteLine($"Int call: {descInt}");

        // Calling the double overload
        string descDouble = Describe(doubleNum);
        Console.WriteLine($"Double call: {descDouble}");


        // --- 3. Test Recursive Method ---
        int testSum = 5;
        int resultSum = SumUpTo(testSum);
        Console.WriteLine("\n[3. Recursive SumUpTo Method]");
        Console.WriteLine($"Sum of numbers from 1 to {testSum}: {resultSum}");
        // Verification check
        if (resultSum == 15)
        {
            Console.WriteLine("Verification successful: SumUpTo(5) = 15.");
        }


        // --- 4. Test Vowel Counting Method ---
        string testString1 = "Programming";
        string testString2 = "Rhythm"; // No vowels
        string testString3 = "AEIOUaeiou"; // All vowels

        Console.WriteLine("\n[4. Vowel Counting Method]");
        
        // Test 1
        int count1 = CountVowels(testString1);
        Console.WriteLine($"The string '{testString1}' contains {count1} vowels.");

        // Test 2
        int count2 = CountVowels(testString2);
        Console.WriteLine($"The string '{testString2}' contains {count2} vowels.");

        // Test 3
        int count3 = CountVowels(testString3);
        Console.WriteLine($"The string '{testString3}' contains {count3} vowels.");
    }
}
*/