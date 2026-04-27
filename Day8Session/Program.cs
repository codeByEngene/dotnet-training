/*
 1. LINQ
*/



//*************************************************** LINQ (Language Integrated Query) ******************************************************//
//LINQ lets you query any collection (arrays, lists, databases, XML) using a clean, readable syntax — similar to SQL but inside C#. 
//There are two ways to write LINQ:
//Query Syntax (SQL-like) and
//Method Syntax (using lambda functions). Both produce the same results.
// The same query written both ways — both give identical results
// Where -> OrderBy -> Skip/Take -> Select -> ToList

// select * from tblAbc abc where abc.Name = "Rashik"

/*
int[] numbers = { 5, 3, 9, 1, 7, 2, 8, 4, 6 };
// Query Syntax (looks like SQL)
var result1 = from n in numbers
              where n > 4
              orderby n
              select n;
Console.WriteLine(string.Join(",", result1));
// Method Syntax (chained methods)
var result2 = numbers.Where(n => n > 4).OrderBy(n => n);
foreach(var r in result2)
{
    Console.WriteLine(r);
}
Console.WriteLine(string.Join(",", result2));
// Both give: 5, 6, 7, 8, 9
*/

/*
// Our data model
class Product
{
    public int    Id       { get; set; }
    public string Name     { get; set; }
    public string Category { get; set; }
    public double Price    { get; set; }
    public int    Stock    { get; set; }
    public bool   InStock  => Stock > 0;
}

//  Main
class Program
{
    static void Main()
    {
        // Sample data — we'll use this throughout all LINQ examples
        List<Product> products = new List<Product>
        {
            new Product { Id=1, Name="Laptop",    Category="Electronics", Price=999.99, Stock=15 },
            new Product { Id=2, Name="Phone",     Category="Electronics", Price=699.99, Stock=30 },
            new Product { Id=3, Name="Headphones",Category="Electronics", Price=149.99, Stock=0  },
            new Product { Id=4, Name="Desk",      Category="Furniture",   Price=299.99, Stock=8  },
            new Product { Id=5, Name="Chair",     Category="Furniture",   Price=199.99, Stock=12 },
            new Product { Id=6, Name="Notebook",  Category="Stationery",  Price=4.99,  Stock=100 },
            new Product { Id=7, Name="Pen",       Category="Stationery",  Price=1.99,  Stock=500 },
            new Product { Id=8, Name="Monitor",   Category="Electronics", Price=399.99, Stock=0  },
        };


              
        // foreach (var product in products)
        // {
        //     Console.WriteLine(product.Name);
        // }

        //************************************************* Basic filter :Where — Filtering *************************************************/
        // var expensive = products.Where(p => p.Price > 200);
        // foreach (var p in expensive)
        //     Console.WriteLine($"{p.Name}: ${p.Price}");
        // // Laptop, Phone, Desk, Monitor
        //
        // // Multiple conditions
        // var electronics = products.Where(p => p.Category == "Electronics" && p.InStock);
        //
        // // Query syntax equivalent
        // var electronics2 = from p in products
        //                 where p.Category == "Electronics" && p.InStock
        //                 select p;
        //
        // // Filter with string methods
        // var containsO = products.Where(p => p.Name.Contains("o", StringComparison.OrdinalIgnoreCase));
        //
        // // Count filtered results
        // int outOfStock = products.Count(p => p.Stock == 0);
        // Console.WriteLine($"Out of stock: {outOfStock}");  // 2





        //************************************************* Select — Projection (Transform) *************************************************/
        // // Get just the names
        // var names = products.Select(p => p.Name);
        // Console.WriteLine(string.Join(", ", names));
        
        // // Get names as uppercase
        // var upperNames = products.Select(p => p.Name.ToUpper());
        
        // // Create a new anonymous object
        // var summary = products.Select(p => new { p.Name, p.Price, Discounted = p.Price * 0.9 });
        
        // foreach (var item in summary)
        //     Console.WriteLine($"{item.Name}: ${item.Price:F2} → ${item.Discounted:F2}");
        
        // // Select with index
        // var numbered = products.Select((p, i) => $"{i+1}. {p.Name}");
        // foreach (var n in numbered)
        //     Console.WriteLine(n);
        
        // // SelectMany — flatten nested collections
        // List<List<int>> nested = new List<List<int>>
        // {
        //     new List<int> { 1, 2, 3 },
        //     new List<int> { 4, 5 },
        //     new List<int> { 6, 7, 8, 9 }
        // };
        
        // var flat = nested.SelectMany(list => list);
        // Console.WriteLine(string.Join(", ", flat)); // 1,2,3,4,5,6,7,8,9




        

        //************************************************* OrderBy / OrderByDescending — Sorting *************************************************/
        // // Sort by price ascending
        // var cheapest = products.OrderBy(p => p.Price).ToList();
        //
        // // Sort by price descending
        // var mostExpensive = products.OrderByDescending(p => p.Price).ToList();
        //
        // // Sort by category, then by price within category
        // var sorted = products.OrderBy(p => p.Category).ThenBy(p => p.Price).ToList();
        //
        // foreach (var p in sorted)
        //     Console.WriteLine($"{p.Category,-15} {p.Name,-15} ${p.Price:F2}");
        //
        // // Sort strings: alphabetically
        // var byName = products.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase);
        //
        // // Query syntax sort
        // var sorted2 = from p in products
        //             orderby p.Category ascending, p.Price descending
        //             select p;





        //************************************************* Aggregate Methods — Count, Sum, Min, Max, Average *************************************************/
        // // Count
        // int total    = products.Count();                           // 8
        // int inStock  = products.Count(p => p.Stock > 0);          // 6
        //
        // // Sum
        // double totalValue = products.Sum(p => p.Price);           // sum of all prices
        // int totalStock    = products.Sum(p => p.Stock);           // total items
        //
        // // Min & Max
        // double minPrice = products.Min(p => p.Price);             // 1.99
        // double maxPrice = products.Max(p => p.Price);             // 999.99
        //
        // // Find the actual cheapest/most expensive object
        // Product cheapest  = products.MinBy(p => p.Price);         // Pen
        // Product dearest   = products.MaxBy(p => p.Price);         // Laptop


        


        //************************************************* GroupBy — Grouping *************************************************/
        // // Group products by category
        // var byCategory = products.GroupBy(p => p.Category).ToList();
        //
        // foreach (var group in byCategory)
        // {
        //     Console.WriteLine($"\n=== {group.Key} ===");
        //     foreach (var p in group)
        //         Console.WriteLine($"  {p.Name}: ${p.Price}");
        // }
        //
        // // Group and get count/total per group
        // var stats = products.GroupBy(p => p.Category).Select(g => new
        // {
        //     Category  = g.Key,
        //     Count     = g.Count(),
        //     Total     = g.Sum(p => p.Price),
        //     Average   = g.Average(p => p.Price),
        //     MaxPrice  = g.Max(p => p.Price),
        // }).ToList();
        //
        // foreach (var stat in stats)
        //     Console.WriteLine($"{stat.Category}: {stat.Count} items, avg ${stat.Average:F2}");
        //
        // // Query syntax
        // var byCategory2 = from p in products
        //                 group p by p.Category into g
        //                 select new { Category = g.Key, Count = g.Count() };



        
        //************************************************* Element Access — First, Last, Single, Any, All *************************************************/
        // // First — gets first item (throws if empty)
        // Product first = products.First();
        // Product firstExpensive = products.First(p => p.Price > 500);  // Laptop
        //
        // // FirstOrDefault — returns null if not found (safe!)
        // Product found  = products.FirstOrDefault(p => p.Name == "Laptop");
        // Product notFound = products.FirstOrDefault(p => p.Price > 10000); // null
        //
        // if (found != null)
        //     Console.WriteLine($"Found: {found.Name}");
        //
        // // Last / LastOrDefault
        // Product last = products.Last();
        // Product lastCheap = products.LastOrDefault(p => p.Price < 10);
        //
        // // Single — expects EXACTLY ONE match (throws if 0 or 2+ found)
        // Product laptop = products.Single(p => p.Name == "Laptop");
        // Product safe   = products.SingleOrDefault(p => p.Id == 99); // null, no throw
        //
        // // Any — is there at least one match?
        // bool hasExpensive = products.Any(p => p.Price > 900);  // true
        // bool hasGames     = products.Any(p => p.Category == "Games"); // false
        //
        // // All — do ALL items match?
        // bool allPositive = products.All(p => p.Price > 0);  // true
        // bool allInStock  = products.All(p => p.Stock > 0);  // false
        //
        // // Contains (direct value check)
        // var names = new[] { "Alice", "Bob", "Carol" };
        // bool hasBob = names.Contains("Bob");  // true





        //************************************************* Skip, Take, Distinct — Paging & Deduplication *************************************************/
        // // Take — get first N items
        // var top3 = products.OrderByDescending(p => p.Price).Take(3);
        // foreach (var p in top3) Console.WriteLine(p.Name);
        //
        // // Skip — skip first N items
        // var after3 = products.Skip(3);
        //
        // // Skip + Take together = PAGINATION
        // int pageSize = 3;
        // int page = 0;  // 0-based
        //
        // var page1 = products.Skip(page * pageSize).Take(pageSize).ToList();  // items 1-3
        // var page2 = products.Skip(1   * pageSize).Take(pageSize).ToList();   // items 4-6
        //
        // // SkipWhile / TakeWhile — skip/take while condition is true
        // int[] numbers = { 2, 4, 6, 7, 8, 10 };
        // var evenThenStop = numbers.TakeWhile(n => n % 2 == 0).ToList(); // 2,4,6 (stops at 7)
        // var afterEven    = numbers.SkipWhile(n => n % 2 == 0).ToList(); // 7,8,10
        //
        // // Distinct — remove duplicates
        // int[] withDupes = { 1, 2, 2, 3, 3, 3, 4 };
        // var unique = withDupes.Distinct().ToList();
        // Console.WriteLine(string.Join(", ", unique));  // 1, 2, 3, 4
        //
        // // DistinctBy (C# 6+) — unique by a property
        // var distinctCategories = products.DistinctBy(p => p.Category);
        // foreach (var p in distinctCategories)
        //     Console.WriteLine(p.Category);  // Electronics, Furniture, Stationery





        //************************************************* Join — Combining Two Collections *************************************************/
        // // Two data sets to join
        // var products2 = new[]
        // {
        //     new { Id = 1, Name = "Laptop",  CategoryId = 1 },
        //     new { Id = 2, Name = "Desk",    CategoryId = 2 },
        //     new { Id = 3, Name = "Notebook",CategoryId = 3 },
        // };
        //
        // var categories = new[]
        // {
        //     new { Id = 1, Label = "Electronics" },
        //     new { Id = 2, Label = "Furniture"   },
        //     new { Id = 3, Label = "Stationery"  },
        // };
        //
        // // Inner Join — only matching items
        // var joined = products2.Join(
        //     categories,
        //     p => p.CategoryId,           // key from products
        //     c => c.Id,                   // key from categories
        //     (p, c) => new { p.Name, c.Label }  // result shape
        // );
        //
        // foreach (var item in joined)
        //     Console.WriteLine($"{item.Name} → {item.Label}");
        //
        // // Query syntax join
        // var joined2 = from p in products2
        //             join c in categories on p.CategoryId equals c.Id
        //             select new { p.Name, c.Label };
        //
        // // GroupJoin — left outer join equivalent
        // var leftJoin = categories.GroupJoin(
        //     products2,
        //     c => c.Id,
        //     p => p.CategoryId,
        //     (cat, prods) => new { cat.Label, Products = prods }
        // );
        //
        // foreach (var cat in leftJoin)
        // {
        //     Console.Write($"{cat.Label}: ");
        //     Console.WriteLine(string.Join(", ", cat.Products.Select(p => p.Name)));
        // }
        



        //************************************************* Set Operations — Union, Intersect, Except, Zip *************************************************/
        // int[] a = { 1, 2, 3, 4, 5 };
        // int[] b = { 3, 4, 5, 6, 7 };
        //
        // // Union — all unique items from both
        // var union = a.Union(b);
        // Console.WriteLine(string.Join(",", union));      // 1,2,3,4,5,6,7
        //
        // // Intersect — items in BOTH
        // var intersect = a.Intersect(b);
        // Console.WriteLine(string.Join(",", intersect));  // 3,4,5
        //
        // // Except — items in a NOT in b
        // var except = a.Except(b);
        // Console.WriteLine(string.Join(",", except));     // 1,2
        //
        // // Concat — join two sequences (keeps duplicates)
        // var concat = a.Concat(b);
        // Console.WriteLine(string.Join(",", concat));     // 1,2,3,4,5,3,4,5,6,7
        //
        // // Zip — pair items from two collections together
        // string[] names = { "Alice", "Bob", "Carol" };
        // int[]    scores = { 92,     85,    78 };
        //
        // var zipped = names.Zip(scores, (name, score) => $"{name}: {score}").ToList();
        // foreach (var z in zipped)
        //     Console.WriteLine(z);  // Alice: 92, Bob: 85, Carol: 78






        //************************************************* Deferred vs Immediate Execution *************************************************/
        //This is an important concept: 
        //LINQ queries don't run immediately when you write them — they run when you iterate over results (deferred). Use ToList() or ToArray() 
        //to force immediate execution.

        //Common Mistake: Writing a LINQ query in a loop without calling ToList() means the query re-executes every iteration! Always call 
        // // .ToList() if you use the result more than once.
        // List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        //
        // // DEFERRED — query built but NOT run yet
        // var query = numbers.Where(n => n > 2);
        //
        // // Modify the source BEFORE iterating
        // numbers.Add(6);
        //
        // // NOW the query runs — includes 6 because we added it before iteration
        // foreach (var n in query)
        //     Console.WriteLine(n);  // 3, 4, 5, 6
        //
        // // IMMEDIATE — query runs right now and result is fixed
        // List<int> snapshot = numbers.Where(n => n > 2).ToList();
        //
        // numbers.Add(99);  // Too late — snapshot was already taken
        //
        // foreach (var n in snapshot)
        //     Console.WriteLine(n);  // 3, 4, 5, 6 (no 99)
        //
        // // Force immediate with: ToList(), ToArray(), ToDictionary(), Count(), Sum() etc.
        //
        // // Convert query result to Dictionary
        // var dict = products.ToDictionary(p => p.Id, p => p.Name);
        // Console.WriteLine(dict[1]);  // Laptop
        //
        // // ToLookup — like dictionary but allows multiple values per key
        // var lookup = products.ToLookup(p => p.Category);
        // foreach (var p in lookup["Electronics"])
        //     Console.WriteLine(p.Name);
    //}
    
//}





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
/*

1. You have a List<Transaction> (where each object has an Amount, Category, and Date). Write a logic that:
    a. Uses LINQ to filter transactions from the last 30 days.
    b. Groups these transactions by Category and calculates the total sum per category.
    c. Store these results into a Dictionary<string, decimal> (Category as key, Sum as value).
    d. Finally, uses LINQ to return a List of the top 3 categories with the highest spending, sorted descending.
*/
//Solution:
// namespace TransactionAnalysis
// {
//     // 1. Define the Transaction class
//     public class Transaction
//     {
//         public decimal Amount { get; set; }
//         public string Category { get; set; }
//         public DateTime Date { get; set; }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Creating a dummy list of transactions for testing
//             List<Transaction> transactions = new List<Transaction>
//             {
//                 new Transaction { Amount = 50.00m, Category = "Food", Date = DateTime.Now.AddDays(-5) },
//                 new Transaction { Amount = 20.00m, Category = "Food", Date = DateTime.Now.AddDays(-10) },
//                 new Transaction { Amount = 100.00m, Category = "Electronics", Date = DateTime.Now.AddDays(-2) },
//                 new Transaction { Amount = 30.00m, Category = "Transport", Date = DateTime.Now.AddDays(-1) },
//                 new Transaction { Amount = 150.00m, Category = "Electronics", Date = DateTime.Now.AddDays(-15) },
//                 new Transaction { Amount = 10.00m, Category = "Food", Date = DateTime.Now.AddDays(-40) }, // Should be filtered out (> 30 days)
//                 new Transaction { Amount = 200.00m, Category = "Rent", Date = DateTime.Now.AddDays(-20) },
//                 new Transaction { Amount = 40.00m, Category = "Transport", Date = DateTime.Now.AddDays(-5) },
//                 new Transaction { Amount = 60.00m, Category = "Entertainment", Date = DateTime.Now.AddDays(-10) },
//             };

//             // --- STEP A & B & C: Filter, Group, Sum and Store in Dictionary ---
            
//             // Define the cutoff date (30 days ago from today)
//             DateTime cutoffDate = DateTime.Now.AddDays(-30);

//             Dictionary<string, decimal> categoryTotals = transactions
//                 // a. Filter: Only keep transactions where the date is within the last 30 days
//                 .Where(t => t.Date >= cutoffDate) 
                
//                 // b. Group: Group all transactions that have the same Category string
//                 .GroupBy(t => t.Category) 
                
//                 // c. Store into Dictionary: 
//                 // The 'g' represents each Group. 
//                 // g.Key is the Category name.
//                 // g.Sum(t => t.Amount) adds up all the Amounts within that specific group.
//                 .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

//             // --- STEP D: Get the top 3 categories with highest spending ---

//             List<string> topCategories = categoryTotals
//                 // Sort by the Value (the sum) in descending order (highest first)
//                 .OrderByDescending(pair => pair.Value) 
                
//                 // Take only the first 3 elements from the sorted list
//                 .Take(3) 
                
//                 // Select only the Key (Category Name) from the Dictionary pair
//                 .Select(pair => pair.Key) 
                
//                 // Convert the final LINQ result into a List<string>
//                 .ToList();

//             // Print results to console
//             Console.WriteLine("Top 3 Spending Categories in the last 30 days:");
//             foreach (var cat in topCategories)
//             {
//                 Console.WriteLine($"- {cat}: ${categoryTotals[cat]}");
//             }
//         }
//     }
// }




/*
2. Design a simple 'Recent Items' cache system.
    a. Use a Queue<string> to track the order of items added.
    b. Use a HashSet<string> to ensure that no duplicate items are ever added to the queue (check the set before enqueuing).
    c. When the queue exceeds 10 items, remove the oldest item from both the Queue and the HashSet.
    d. Write a method that returns the current cache items as a sorted string[] (Array) using LINQ.
*/
//Solution:
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace CacheSystem
// {
//    public class RecentItemsCache
//    {
//        // a. Queue tracks the order. First item in is the first one to be removed.
//        private readonly Queue<string> _order = new Queue<string>();
       
//        // b. HashSet allows us to check if an item exists instantly (O(1) time complexity)
//        private readonly HashSet<string> _uniqueItems = new HashSet<string>();
       
//        private const int MaxCapacity = 10;

//        public void AddItem(string item)
//        {
//            // b. Check if the item is already in the HashSet before adding
//            // This ensures no duplicates are ever added to the queue
//            if (_uniqueItems.Contains(item))
//            {
//                Console.WriteLine($"Item '{item}' is already in cache. Skipping...");
//                return;
//            }

//            // Add to both structures
//            _uniqueItems.Add(item);
//            _order.Enqueue(item);
//            Console.WriteLine($"Added: {item}");

//            // c. If queue exceeds 10 items, remove the oldest
//            if (_order.Count > MaxCapacity)
//            {
//                // Dequeue() removes and returns the oldest item (the one at the front)
//                string oldestItem = _order.Dequeue();
               
//                // We must also remove it from the HashSet so it can be added again in the future
//                _uniqueItems.Remove(oldestItem);
               
//                Console.WriteLine($"Cache full. Removed oldest item: {oldestItem}");
//            }
//        }

//        // d. Method to return current items as a sorted string array
//        public string[] GetSortedItems()
//        {
//            // We take the Queue, sort it alphabetically using LINQ, and convert to Array
//            return _order
//                .OrderBy(item => item) // Sorts strings A-Z
//                .ToArray();            // Converts the LINQ result into a string[]
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            RecentItemsCache cache = new RecentItemsCache();

//            // Adding 12 items to test capacity (10) and duplicates
//            string[] testItems = { 
//                "Apple", "Banana", "Cherry", "Date", "Elderberry", 
//                "Fig", "Grape", "Honeydew", "Iceberg", "Jackfruit", 
//                "Kiwi", "Lemon" 
//            };

//            foreach (var item in testItems)
//            {
//                cache.AddItem(item);
//            }

//            // Test duplicate addition
//            cache.AddItem("Apple");

//            // Get the sorted list
//            string[] sortedResults = cache.GetSortedItems();

//            Console.WriteLine("\n--- Final Sorted Cache Items ---");
//            foreach (var item in sortedResults)
//            {
//                Console.WriteLine(item);
//            }
//        }
//    }
// }
   
    
    

/*
3. You have a List<User> where each user has an Id, Username, and a List<int> of scores.
    a. Create a Dictionary<int, int> where the key is the UserId and the value is the sum of that user's scores (calculated via LINQ).
    b. Using this dictionary, write a LINQ query to find all Usernames whose total score is above the average of all users.
    c. Return the final list of usernames as a List<string> sorted alphabetically.
*/
//Solution:

// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace UserScoreAnalysis
// {
//     // Define the User class
//     public class User
//     {
//         public int Id { get; set; }
//         public string Username { get; set; }
//         public List<int> Scores { get; set; }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Setup dummy data
//             List<User> users = new List<User>
//             {
//                 new User { Id = 1, Username = "Alice", Scores = new List<int> { 10, 20, 30 } },    // Total: 60
//                 new User { Id = 2, Username = "Bob", Scores = new List<int> { 5, 5, 5 } },        // Total: 15
//                 new User { Id = 3, Username = "Charlie", Scores = new List<int> { 100, 50 } },   // Total: 150
//                 new User { Id = 4, Username = "Diana", Scores = new List<int> { 20, 20, 20 } },   // Total: 60
//                 new User { Id = 5, Username = "Eve", Scores = new List<int> { 10, 10 } },        // Total: 20
//             };

//             // --- STEP A: Create Dictionary<UserId, TotalScore> ---
            
//             // ToDictionary(keySelector, elementSelector)
//             // keySelector: use the Id as the key
//             // elementSelector: sum the list of scores as the value
//             Dictionary<int, int> userTotalScores = users
//                 .ToDictionary(u => u.Id, u => u.Scores.Sum());

//             // --- STEP B & C: Find usernames above average and sort them ---

//             // 1. First, calculate the average of all the totals we just calculated
//             // We use .Values to get only the sums from our dictionary
//             double averageScore = userTotalScores.Values.Average();
//             Console.WriteLine($"Average Score: {averageScore:F2}");

//             // 2. Now we filter the original users list
//             List<string> topUsers = users
//                 // Filter: Look up the user's total score in our dictionary and compare to average
//                 .Where(u => userTotalScores[u.Id] > averageScore)
                
//                 // Project: We only want the Username string, not the whole User object
//                 .Select(u => u.Username)
                
//                 // Sort: Order alphabetically (A-Z)
//                 .OrderBy(name => name)
                
//                 // Finalize: Convert the LINQ result to a List
//                 .ToList();

//             // Print the final result
//             Console.WriteLine("Users with above-average scores (Sorted):");
//             foreach (var name in topUsers)
//             {
//                 Console.WriteLine($"- {name}");
//             }
//         }
//     }
// }




/*
4. You have a Dictionary<string, List<Employee>> where the key is the Department Name and the value is a list of employees in that department.
    a. Use LINQ SelectMany to flatten all employees from all departments into one single sequence.
    b. Filter this sequence to find employees who earn more than $50,000.
    c. Transform (Project) these employees into a List of their full names (FirstName + LastName).
    d. Convert the final result into an Array.
*/

//Solution:

// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EmployeeAnalysis
// {
//     // Define the Employee class
//     public class Employee
//     {
//         public string FirstName { get; set; }
//         public string LastName { get; set; }
//         public decimal Salary { get; set; }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Setup: A Dictionary where Key = Department Name, Value = List of Employees
//             Dictionary<string, List<Employee>> companyDepartments = new Dictionary<string, List<Employee>>
//             {
//                 { "IT", 
//                     new List<Employee> 
//                     { 
//                         new Employee { FirstName = "John", LastName = "Doe", Salary = 60000 }, 
//                         new Employee { FirstName = "Jane", LastName = "Smith", Salary = 45000 } 
//                     }
//                 },
//                 { "HR", new List<Employee> { 
//                     new Employee { FirstName = "Alice", LastName = "Johnson", Salary = 55000 }, 
//                     new Employee { FirstName = "Bob", LastName = "Brown", Salary = 40000 } 
//                 }},
//                 { "Sales", new List<Employee> { 
//                     new Employee { FirstName = "Charlie", LastName = "Davis", Salary = 70000 }, 
//                     new Employee { FirstName = "Diana", LastName = "Prince", Salary = 51000 } 
//                 }}
//             };

//             // --- LINQ Pipeline ---

//             Employee[] highEarnerss = 
//                 companyDepartments.SelectMany(deptPair => deptPair.Value).ToArray(); 
            
            
//             string[] highEarners = companyDepartments
//                 // a. SelectMany: "Flattening"
//                 // The dictionary contains KeyValuePairs. We only care about the Value (the List<Employee>).
//                 // SelectMany takes all the lists from all departments and merges them into one big sequence of Employees.
//                 .SelectMany(deptPair => deptPair.Value) 
                
//                 // b. Filter: Keep only those earning more than 50,000
//                 .Where(emp => emp.Salary > 50000)
                
//                 // c. Project: Transform the Employee object into a single "Full Name" string
//                 .Select(emp => $"{emp.FirstName} {emp.LastName}")
                
//                 // d. Convert the final sequence into an Array
//                 .ToArray();

//             // Print results to console
//             Console.WriteLine("Employees earning more than $50,000:");
//             foreach (var name in highEarners)
//             {
//                 Console.WriteLine($"- {name}");
//             }
//         }
//     }
// }




