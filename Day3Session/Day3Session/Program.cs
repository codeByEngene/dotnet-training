//************************************ Control Flow ************************************//
/*
1. if else
2. switch case
3. loops (for, while, do-while, foreach)
4. break and continue
*/

//************************************ If Else Syntax ************************************//
/*
    if(condition)
    {
        //code to execute if condition is true
    }
    else if(condition2)
    {
        //code to execute if condition2 is true
    }
    else
    {
        //code to execute if condition is false
    }
*/


//************************************ If Else Example ************************************//
/*
Console.WriteLine("Enter the color of the traffic light:");
string trafficLight = Console.ReadLine().ToUpper(); // Convert input to uppercase for case-insensitive comparison
if(trafficLight == "RED")
{
    Console.ForegroundColor = ConsoleColor.Red; // Change text color to red
    Console.WriteLine("Stop");
}
else if(trafficLight == "YELLOW")
{
    Console.ForegroundColor = ConsoleColor.Yellow; // Change text color to yellow
    Console.WriteLine("Get Ready");
}
else if(trafficLight == "GREEN")
{
    Console.ForegroundColor = ConsoleColor.Green; // Change text color to green
    Console.WriteLine("Go");
}
else
{
    Console.WriteLine("Invalid traffic light color");
}
*/


//************************************ Switch case statement ************************************//
/*
    switch(expression)
    {
        case value1:
            //code to execute if expression equals value1
            break;
        case value2:
            //code to execute if expression equals value2
            break;
        default:
            //code to execute if expression does not match any case
            break;
    }
*/


//************************************ Switch Case Example ************************************//
/*
string dayName;
Console.WriteLine("Enter a number between 1 and 7 to get the corresponding day of the week:");
int dayOfWeek = int.Parse(Console.ReadLine());
switch(dayOfWeek)
{
    case 1:
        dayName = "Sunday";
        break;
    case 2:
        dayName = "Monday";
        break;
    case 3:
        dayName = "Tuesday";
        break;
    case 4:
        dayName = "Wednesday";
        break;
    case 5:
        dayName = "Thursday";
        break;
    case 6:
        dayName = "Friday";
        break;
    case 7:
        dayName = "Saturday";
        break;
    default:
        dayName = "Invalid day of the week";
        break;
}
Console.WriteLine($"The day is {dayName}"); 
*/


//************************************ Loops ************************************//
/*
1. For loop
2. While loop
3. Do-while loop
4. Foreach loop
*/


//************************************ For Loop Syntax ************************************//
/*
    int initialization = 0; // Initialize loop variable
    while(initialization < 5) // Condition to continue loop
    initizialization++; // Increment loop variable
    for(initialization; condition; increment/decrement)
    {
        //code to execute
    }

    for(int i = initialization; i < condition; i += increment/decrement)
    {
        //code to execute
    }
*/


//************************************ For Loop Example ************************************//
/*
int sum = 0;
Console.WriteLine("Calculating the sum of the first user defined natural numbers...");
int maxNumber = int.Parse(Console.ReadLine());
for(int i = 1; i <= maxNumber; i++)
{
    sum += i; // Add i to sum
}
Console.WriteLine($"The sum of the first user defined natural numbers is: {sum}");
*/


//************************************ While Loop Syntax ************************************//
/*
    while(condition)
    {      
        //code to execute
    }
*/


//************************************ While Loop Example ************************************//
/*
Console.WriteLine("Counting from 1 to user defined number using a while loop...");
int count = 0;
int maxCount = int.Parse(Console.ReadLine());
Console.WriteLine($"Counting from 1 to {maxCount} using a while loop...");
while(count < maxCount)
{           
    count++;
    Console.WriteLine(count); 
}
*/


//************************************ Do-while Loop Syntax ************************************//
/*
    do
    {
        //code to execute               
    } while(condition);
*/


//************************************ Do-While Loop Example ************************************//
/*
Console.WriteLine("Counting from 1 to user defined number using a do-while loop...");           
int count = 0;
int maxCount = int.Parse(Console.ReadLine());
Console.WriteLine($"Counting from 1 to {maxCount} using a do-while loop...");
do
{
    count++;
    Console.WriteLine(count);
} while(count < maxCount);  
*/


//************************************ Foreach loop ************************************//
/*
    foreach(var item in collection)
    {
        //code to execute
    }
*/


//************************************ Foreach Loop Example ************************************//
/*
int[] numbers = new int[3] { 1, 2, 3 };
Console.WriteLine("The numbers in the array are:");
foreach(int i in numbers)
{
    Console.WriteLine(i);
}

string[] shoppingList = { "Milk", "Bread", "Eggs", "Butter", "Cheese" };
Console.WriteLine("Your shopping list:");
foreach(string item in shoppingList)
{
    Console.WriteLine(item);
}
*/


//************************************ Break and Continue ************************************//
/*
1. break - exits the current loop or switch statement
2. continue - skips the current iteration of the loop and moves to the next iteration
*/


//************************************ Break Example ************************************//
/*
Console.WriteLine("Searching for a student named mentioned by the user in the class...");
string studentName = Console.ReadLine().ToUpper(); // Convert input to uppercase for case-insensitive comparison
string [] students = { "Alice", "Bob", "Charlie", "David", "Eve" };
Console.WriteLine("Students in the class:");
for(int i = 0; i < students.Length; i++)
{
    if(students[i].ToUpper() == studentName)
    {
        Console.WriteLine($"{studentName} is found, breaking the loop.");
        break; // Exit the loop when Charlie is found
    }
    Console.WriteLine(students[i]);
}
*/


//************************************ Continue Example ************************************//
/*
for(int i = 1; i <= 10; i++)
{
    if(i % 2 == 0)
    {
        continue; // Skip even numbers
    }
    Console.WriteLine(i); // Print odd numbers
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
//1. Write a program that prints a multiplication table for any number entered by the user (e.g., 7 × 1 through 7 × 10).
//Solution:
/*
Console.WriteLine("--- Multiplication Table (For Loop) ---");
Console.WriteLine("Enter a number to print its multiplication table:");
int number = int.Parse(Console.ReadLine());
Console.WriteLine($"Multiplication Table for {number}:");
for(int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{number} x {i} = {number * i}");
}
*/


// 2. Use a switch statement: ask the user to enter a season number (1=Spring, 2=Summer, 3=Autumn, 4=Winter) and print the season name and its typical activities.
//Solution:
/*
Console.WriteLine("--- Season Check (Switch Statement) ---");
Console.Write("Enter a month number (1-12): ");

int month = int.Parse(Console.ReadLine());
string season = "";

// Using the switch statement to determine the season
switch (month)
{
    case 12: // December
    case 1:  // January
    case 2:  // February
        season = "Winter";
        break;
    case 3:  // March
        season = "Spring";
        break;
    case 4:  // April
    case 5:  // May
    case 6:  // June
        season = "Spring/Summer Transition";
        break;
    case 7:  // July
    case 8:  // August
    case 9:  // September
        season = "Summer/Autumn Transition";
        break;
    case 10: // October
    case 11: // November
        season = "Autumn/Winter Transition";
        break;
    default:
        season = "Invalid month number entered.";
        break;
}
Console.WriteLine($"\nThe month number {month} typically falls during {season}.");
*/


// 3. Use a while loop to simulate a bank ATM: start with a balance of Rs 10,000. Let the user withdraw money repeatedly until the balance is 0 or they choose to exit.
//Solution:
/*
Console.WriteLine("--- ATM Simulation (Do-While Loop) ---");
double balance = 5000.00;
Console.WriteLine($"Welcome! Initial Balance: ${balance:N2}");

// Use a do-while loop to keep running until the balance hits zero
bool running = true;

do
{
    Console.WriteLine("\n---------------------------------");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Check Balance");
    Console.WriteLine("2. Withdraw Money");
    Console.WriteLine("3. Exit ATM");
    Console.Write("Enter choice (1, 2, or 3): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine($"\n[INFO] Your current balance is: ${balance:N2}");
            break;

        case "2":
            Console.Write("Enter amount to withdraw: $");
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                if (amount > balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERROR] Insufficient funds. Withdrawal cancelled.");
                    Console.ResetColor();
                }
                else
                {
                    balance -= amount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[SUCCESS] Withdrew ${amount:N2}. New Balance: ${balance:N2}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[ERROR] Invalid amount entered.");
                Console.ResetColor();
            }
            break;

        case "3":
            Console.WriteLine("\nThank you for using the ATM. Goodbye!");
            running = false;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] Invalid option. Please try again.");
            Console.ResetColor();
            break;
    }
} while (running && balance > 0);
*/


// 4. Print all numbers from 1 to 100 that are divisible by both 3 and 5 using a for loop and the modulus operator.
//Solution:
/*
Console.WriteLine("--- Numbers divisible by both 3 AND 5 (between 1 and 100) ---");
Console.WriteLine("--------------------------------------------------------------------");

for (int i = 1; i <= 100; i++)
{
    // if(i % 3 == 0)
    // {
    //     if(i % 5 == 0)
    //     {
    //         Console.WriteLine(i);
    //     }
    // }

    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine(i);
    }
}
*/
