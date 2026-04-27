/*
1. Collections
    i. Arrays
    ii. List
    iii. Dictionary
    iv. HashSet
    v. Queue
    vi. Stack
*/

/*
// IEnumerable & IEnumerator — The Foundation
// Everything in C# that can be looped over implements IEnumerable. It is the base interface.
// Understanding it helps you grasp how foreach works under the hood.
// IEnumerable is the base interface for all collections
// Any class that has GetEnumerator() can be used in a foreach loop
//IEnumerable = 'I can be looped'. IEnumerator = 'I do the actual looping'. You rarely implement these manually — C# collections already do it for you.
using System;
using System.Collections;
// Custom class implementing IEnumerable
public class NumberRange : IEnumerable
{
    private int[] numbers;
    public NumberRange(int[] nums) => numbers = nums;
    // Must implement GetEnumerator
    public IEnumerator GetEnumerator()
    {
        return numbers.GetEnumerator();
    }
}
class Program
{
    static void Main()
    {
        var range = new NumberRange(new[] { 10, 20, 30, 40, 50 });
        // foreach works because NumberRange implements IEnumerable
        foreach (var num in range)
        {
            Console.WriteLine(num); // Output: 10, 20, 30, 40, 50
        }
        // Manual way (what foreach does internally)
        IEnumerator e = range.GetEnumerator();
        while (e.MoveNext())
        {
            Console.WriteLine(e.Current);
        }
    }
}
*/


//********************************************************** Collections ****************************************************//
//************************************************************* Arrays ******************************************************//
//Arrays store a fixed number of elements of the same type. Size cannot change after creation. Best used when you know the exact count upfront.
//Use an array when the size is known and fixed — like the 12 months, 7 days of week, or a chess board (8x8).
/*
class ArrayExamples
{
    static void Main()
    {
        // ── 1D Array ──────────────────────────────────────────
        int[] scores = new int[5];        // Creates array of 5 zeros
        scores[0] = 95;
        scores[1] = 87;
        scores[2] = 92;
 
        // Initialize with values directly
        string[] fruits = { "Apple", "Banana", "Cherry", "Mango" };
 
        // Access elements
        Console.WriteLine(fruits[0]);       // Apple
        Console.WriteLine(fruits.Length);   // 4
 
        // Loop through array
        foreach (string fruit in fruits)
            Console.WriteLine(fruit);
 
        // ── Array Methods ─────────────────────────────────────
        int[] numbers = { 5, 3, 8, 1, 9, 2 };
 
        Array.Sort(numbers);               // Sort in place
        Console.WriteLine(string.Join(", ", numbers)); // 1,2,3,5,8,9
 
        Array.Reverse(numbers);            // Reverse
        Console.WriteLine(string.Join(", ", numbers)); // 9,8,5,3,2,1
 
        int index = Array.IndexOf(numbers, 5); // Find index of 5
        Console.WriteLine(index);          // 2
 
        // Copy array
        int[] copy = new int[6];
        Array.Copy(numbers, copy, numbers.Length);
 
        // ── 2D Array ──────────────────────────────────────────
        int[,] matrix = new int[3, 3];     // 3x3 grid
        matrix[0, 0] = 1; matrix[0, 1] = 2; matrix[0, 2] = 3;
        matrix[1, 0] = 4; matrix[1, 1] = 5; matrix[1, 2] = 6;
 
        // Initialize 2D array with values
        int[,] grid = { {1,2,3}, {4,5,6}, {7,8,9} };
 
        // Loop through 2D array
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                Console.Write(grid[row, col] + " ");
            Console.WriteLine();
        }
 
        // ── Jagged Array (Array of Arrays) ────────────────────
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 2 };
        jagged[1] = new int[] { 3, 4, 5 };
        jagged[2] = new int[] { 6 };
 
        foreach (var row in jagged)
            Console.WriteLine(string.Join(", ", row));
    }
}
*/





//************************************************************* Lists ******************************************************//
// List<T> is your go-to collection.
// It resizes automatically as you add items. It's like an array but flexible. 
/*
class ListExamples
{
    static void Main()
    {
        // Create a list
        List<string> names = new List<string>();
 
        // Add items
        names.Add("Alice");
        names.Add("Bob");
        names.Add("Charlie");
        names.Add("Diana");
 
        // Add multiple at once
        names.AddRange(new[] { "Eve", "Frank" });
 
        // Insert at specific position
        names.Insert(1, "Anna");  // Insert at index 1
 
        Console.WriteLine($"Count: {names.Count}");       // 7
        Console.WriteLine($"First: {names[0]}");          // Alice
        Console.WriteLine($"Last:  {names[names.Count-1]}"); // Frank
 
        // Check if item exists
        Console.WriteLine(names.Contains("Bob"));         // True
 
        // Find index
        Console.WriteLine(names.IndexOf("Charlie"));      // 3 (after insert)
 
        // Remove items
        names.Remove("Anna");         // Remove by value
        names.RemoveAt(0);            // Remove by index
        names.RemoveAll(n => n.StartsWith("E")); // Remove where condition
 
        // Sort
        names.Sort();
 
        // Loop
        foreach (string name in names)
            Console.WriteLine(name);
 
        // Convert to array
        string[] arr = names.ToArray();
 
        // Clear all
        names.Clear();
        Console.WriteLine($"After clear: {names.Count}"); // 0
 
        List<Student> studentsNew = new List<Student>();
        Student studentValue = new Student();
        studentValue.Name = "Rashik";
        studentValue.Grade = 12;
        studentsNew.Add(studentValue);
        
        Student studentValue1 = new Student();
        studentValue1.Name = "Hari";
        studentValue1.Grade = 11;
        studentsNew.Add(studentValue1);
        
        
        // ── List of objects ───────────────────────────────────
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Grade = 90 },
            new Student { Name = "Bob",   Grade = 75 },
            new Student { Name = "Carol", Grade = 88 }
        };
        
        // Find first match
        Student top = students.Find(s => s.Grade > 85);
        Console.WriteLine(top.Name);  // Alice
 
        // Find all matches
        List<Student> passing = students.FindAll(s => s.Grade >= 80);
        Console.WriteLine(passing.Count); // 2
    }
}
 
class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}
*/


//************************************************************* Dictionary ******************************************************//
//Dictionary stores items as key-value pairs. Keys must be unique.
//Perfect for lookups — like a phone book (name → phone number).
/*
class DictionaryExamples
{
    static void Main()
    {
        // Create dictionary (key=string, value=int)
        Dictionary<string, int> ages = new Dictionary<string, int>();
 
        // Add entries
        ages["Alice"]   = 30;
        ages["Bob"]     = 25;
        ages["Bob"]     = 27;
        ages["Charlie"] = 35;
        ages.Add("Diana", 28);
 
        // Access by key
        Console.WriteLine(ages["Alice"]);         // 30
 
        // Safe access with TryGetValue (no exception if missing)

        if (ages.TryGetValue("Bob", out int bobAge))
            Console.WriteLine($"Bob is {bobAge}"); // Bob is 25
 
        // Check if key exists
        Console.WriteLine(ages.ContainsKey("Eve"));  // False
        Console.WriteLine(ages.ContainsValue(35));    // True
 
        // Update a value
        ages["Alice"] = 31;
 
        // Remove
        ages.Remove("Bob");
 
        // Loop through keys
        foreach (string name in ages.Keys)
            Console.WriteLine(name);
 
        // Loop through values
        foreach (int age in ages.Values)
            Console.WriteLine(age);
 
        // Loop through both (KeyValuePair)
        foreach (KeyValuePair<string, int> entry in ages)
            Console.WriteLine($"{entry.Key} => {entry.Value}");
 
        // Shorter syntax with var
        foreach (var (name, age) in ages)
            Console.WriteLine($"{name} is {age} years old");
 
        // ── Word frequency counter example ────────────────────
        string sentence = "apple banana apple cherry banana apple";

        var abc = sentence.Split(' ');
        
        Dictionary<string, int> freq = new Dictionary<string, int>();
 
        foreach (string word in sentence.Split(' '))
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }
 
        foreach (var pair in freq)
            Console.WriteLine($"{pair.Key}: {pair.Value}x");
    }
}
*/



//************************************************************* HashSet ******************************************************//
//HashSet stores only unique items.
//Automatically ignores duplicates. Great for checking membership and removing duplicates.
/*
class HashSetExamples
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7, 8 };
 
        // Duplicates are ignored automatically
        set1.Add(3);   // Already exists — nothing happens
        set1.Add(6);
        Console.WriteLine(set1.Count);  // 6 (not 7, no duplicate 3)
 
        // Check membership — O(1) speed
        Console.WriteLine(set1.Contains(3));  // True
        Console.WriteLine(set1.Contains(99)); // False
 
        // ── Set operations ────────────────────────────────────
 
        // Union — all items from both sets
        HashSet<int> union = new HashSet<int>(set1);
        union.UnionWith(set2);
        Console.WriteLine("Union: " + string.Join(",", union));
 
        // Intersection — items in BOTH sets
        HashSet<int> intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);
        Console.WriteLine("Intersection: " + string.Join(",", intersection));
 
        // Difference — items in set1 NOT in set2
        HashSet<int> diff = new HashSet<int>(set1);
        diff.ExceptWith(set2);
        Console.WriteLine("Difference: " + string.Join(",", diff));
 
        // ── Remove duplicates from a list ──────────────────────
        List<string> withDupes = new List<string>
            { "cat", "dog", "cat", "bird", "dog", "fish" };
 
        HashSet<string> unique = new HashSet<string>(withDupes);
        Console.WriteLine(string.Join(", ", unique)); // cat, dog, bird, fish
    }
}
*/


//************************************************************* Queue And Stack ******************************************************//
//Queue = First In, First Out (FIFO) — like a checkout line.
//Stack = Last In, First Out (LIFO) — like a stack of plates.
/*
class QueueStackExamples
{
    static void Main()
    {
        // ── Queue<T> (FIFO — First In First Out) ──────────────
        Queue<string> ticketLine = new Queue<string>();
 
        // Enqueue = join the line
        ticketLine.Enqueue("Alice");
        ticketLine.Enqueue("Bob");
        ticketLine.Enqueue("Charlie");
 
        Console.WriteLine($"In line: {ticketLine.Count}");       // 3
        Console.WriteLine($"Next up: {ticketLine.Peek()}");      // Alice (don't remove)
 
        // Dequeue = serve the first person
        string served = ticketLine.Dequeue();
        Console.WriteLine($"Served: {served}");                  // Alice
        Console.WriteLine($"Remaining: {ticketLine.Count}");     // 2
 
        // Process entire queue
        while (ticketLine.Count > 0) 
            Console.WriteLine($"Serving: {ticketLine.Dequeue()}");
 
 
        // ── Stack<T> (LIFO — Last In First Out) ───────────────
        Stack<string> browserHistory = new Stack<string>();
 
        // Push = visit a page
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");
 
        Console.WriteLine($"Current page: {browserHistory.Peek()}"); // stackoverflow.com
 
        // Pop = press Back button
        string back = browserHistory.Pop();
        Console.WriteLine($"Went back from: {back}");  // stackoverflow.com
        Console.WriteLine($"Now on: {browserHistory.Peek()}"); // github.com
 
        // ── Real use: Undo system ──────────────────────────────
        Stack<string> undoStack = new Stack<string>();
        undoStack.Push("Typed 'Hello'");
        undoStack.Push("Typed ' World'");
        undoStack.Push("Deleted 'World'");
 
        Console.WriteLine("Undo: " + undoStack.Pop()); // Undo last action
        Console.WriteLine("Undo: " + undoStack.Pop()); // Undo second-to-last
    }
}
*/


