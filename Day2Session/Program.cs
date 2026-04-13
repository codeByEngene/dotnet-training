//************************************ Identifiers ************************************//
// Identifiers are names used to identify variables, methods, classes, and other elements in C#. They must follow certain rules:
/*
var name = "John";
var _name = "Doe";
*/


//************************************ Data Type ************************************//
// Data types specify the type of data that a variable can hold. C# has several built-in data types, including int, string, double, bool, etc.
/*
//data_type variable_name = value;
int age = 30;
string city = "New York";
double salary = 50000.50;
bool isEmployed = true;
*/


//************************************ Value Type ************************************//
// Value types directly contain their data, and each variable has its own copy of the data. Examples of value types include int, double, bool, etc.
/*
int x = 10;
int y = x; // y is a copy of x
y = 20; // changing y does not affect x
Console.WriteLine($"x: {x}, y: {y}"); // Output: x
*/


//************************************ Reference Type ************************************//
// Reference types store a reference to the actual data, and multiple variables can reference the same data. Examples of reference types include string, arrays, classes, etc.
/*
abc = sdfdsf
bcd = abc
bcd = sadfdsf
print abc;
*/


//************************************ Variables ************************************//
// Variables are used to store data in a program. They have a name, a data type, and a value. The value of a variable can be changed during the execution of the program.
/*
//data_type variable_name = value;
int a;
string b;
*/


//************************************ Constants ************************************//
// Constants are variables whose value cannot be changed after it has been assigned. They are declared using the const keyword and must be initialized at the time of declaration.
// Constant Variables
// Compiletime constant
/*
// const keyword is used to declare a constant variable whose value cannot be changed after it is assigned.
const double PI = 3.14159;
PI = 3.14; // This will cause a compile-time error because PI is a constantq
*/


// Readonly Variables
// Runtime constant
/*
// readonly keyword is used to declare a variable that can only be assigned a value once, either at the time of declaration or in the constructor of the class. Once assigned, its value cannot be changed.
readonly int MAX_VALUE = DateTime.Now.Year;
*/


//************************************ operators ************************************//
//  +, - , *, / , % , ++, --, ==, !=, >, <, >=, <=, &&, ||, !, =, ?:
/*
int num1 = 10;
int num2 = 5;
int sum = num1 + num2; // 15
int difference = num1 - num2; // 5
int product = num1 * num2; // 50
int quotient = num1 / num2; // 2
int remainder = num1 % num2; // 0
string str1 = "Hello";
string str2 = "World";

var abc = str1 == str2 ? "Strings are equal"; : "not equal"; // false : ternary operator
string combined = str1 + " " + str2; // "Hello World"
int count = 0;
count++; // count is now 1
count--; // count is now 0
*/


//************************************ keywords ************************************//
// Keywords are reserved words in C# that have special meaning and cannot be used as identifiers (such as variable names, method names, etc.). They are part of the syntax of the language and are used to define the structure and behavior of C# programs. Examples of keywords include: if, else, for, while, class, public, private, static, void, return, new, try, catch, finally, etc.
/*
var using = "sdf    dsf"; // This will cause a compile-time error because 'using' is a reserved keyword in C#.
*/


//************************************ Naming Convensions ************************************// 
// PascalCase - First letter of each word is capitalized (e.g., MyClass, CalculateSum)
// class, method, namespace 
/*
public class Person
{
    public string Name { get; set; }
    public string Address { get; set; }
*/

// camelCase - First letter of the first word is lowercase, and the first letter of each subsequent word is capitalized (e.g., myVariable, calculateSum)
// variable, parameters
/*
var firstName = "John";
*/


//************************************ Sample Example Including Every Thing On This Session ************************************//
/*
Console.WriteLine("Your Age?");
var age = Console.ReadLine();
Console.WriteLine("Your age " + age);
int nextYearAge = int.Parse(age) + 1;
Console.WriteLine(nextYearAge);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Your age " + age);
Console.WriteLine($"Your Next Year Age Will Be: {nextYearAge}");
Console.WriteLine("Your Next Year Age Will Be: {0}",   nextYearAge);
Console.ResetColor();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
*/
