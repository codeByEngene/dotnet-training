/*
1. Methods (Parameters, Return Types, Overloading)
2. Recursion
*/

//1. Methods
/*

public
private

access_modifier return_type method_name(data_type parameter_name)
{
    //method body
}
return_type -> data_type, void
*/
//Method With Parameters and Return Type
/*
//Method Declaration
int AddTwoNumbers(int a, int b)
{
    return a + b;
}

//Method Call / Invocation
int result = AddTwoNumbers(5, 10);
Console.WriteLine(result); // Output: 15
*/

//Method Without Return Type (void)
/*
void Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

Greet("Alice"); // Output: Hello, Alice!
*/

//Paramterless Method
/*
void Greet()
{
    Console.WriteLine($"Hello!");
}

Greet(); // Output: Hello!
*/



//Method Overloading
/*
using MyNamespace;

Maths maths = new Maths();
maths.Greetings();
maths.Greetings("Alice");
maths.Greetings("Bob", "Kathmandu");

namespace MyNamespace
{
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

        public void Greetings(string name, string address)
        {
            Console.WriteLine($"Hello {name} from {address}!");
        }
    }
}
*/




