//*************************************************** File I/O (Input / Output) ******************************************************//
//File I/O means reading from and writing to files on disk. 
//C# provides powerful classes in System.IO for everything from simple text files to streams, directories, JSON, and more.

// Key namespaces you'll need
/*
using System.IO;           // File, Directory, Path, Stream classes
using System.Text;         // Encoding
using System.Text.Json;    // JSON reading/writing

*/
//
// class FileQuickExamples
// {
//     static void Main()
//     {
//         string path = "/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/data.txt";
//  
//         // ── WRITE ─────────────────────────────────────────────
//  
//         // Write all text (creates or overwrites)
//         File.WriteAllText(path, "Hello, File World!\nLine Two");
//  
//         // Append to existing file
//         File.AppendAllText(path, "\nAppended line");
//  
//         // Write multiple lines
//         string[] lines = { "Line 1", "Line 2", "Line 3" };
//         File.WriteAllLines("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/lines.txt", lines);
//  
//         // Write bytes (binary data)
//         byte[] data = { 72, 101, 108, 108, 111 };  // "Hello" in ASCII
//         File.WriteAllBytes("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/bytes.bin", data);
//  
//         // ── READ ──────────────────────────────────────────────
//  
//         // Read entire file as one string
//         string text = File.ReadAllText(path);
//         Console.WriteLine(text);
//  
//         // Read all lines into an array
//         string[] allLines = File.ReadAllLines("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/lines.txt");
//         foreach (string line in allLines)
//             Console.WriteLine(line);
//  
//         // Read bytes
//         byte[] bytes = File.ReadAllBytes("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/bytes.bin");
//         Console.WriteLine(System.Text.Encoding.ASCII.GetString(bytes)); // Hello
//  
//         // ── CHECK & DELETE ────────────────────────────────────
//  
//         // Check if file exists
//         if (File.Exists(path))
//             Console.WriteLine("File found!");
//  
//         // Copy file
//         File.Copy(path, "/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/data_backup.txt", overwrite: true);
//  
//         // Move (rename) file
//         //File.Move("data_backup.txt", "backup/data_backup.txt", overwrite: true);
//  
//         // Delete file
//         File.Delete("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/data_backup.txt");
//  
//         // Get file info
//         FileInfo info = new FileInfo(path);
//         Console.WriteLine($"Size: {info.Length} bytes");
//         Console.WriteLine($"Created: {info.CreationTime}");
//         Console.WriteLine($"Modified: {info.LastWriteTime}");
//     }
// }



//FileStream & BinaryReader / BinaryWriter
//FileStream gives you raw byte access. BinaryReader/Writer let you read and write primitive types (int, double, bool) as bytes — great for custom file formats.
// class BinaryExamples
// {
//     static void Main()
//     {
//         string path = "/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/scores.bin";
//  
//         // ── Write with BinaryWriter ────────────────────────────
//         using (FileStream fs = new FileStream(path, FileMode.Create))
//         using (BinaryWriter bw = new BinaryWriter(fs))
//         {
//             bw.Write("Alice");   // string
//             bw.Write(92);        // int
//             bw.Write(98.5);      // double
//             bw.Write(true);      // bool
//  
//             bw.Write("Bob");
//             bw.Write(85);
//             bw.Write(91.0);
//             bw.Write(true);
//         }
//  
//         // ── Read with BinaryReader ─────────────────────────────
//         using (FileStream fs = new FileStream(path, FileMode.Open))
//         using (BinaryReader br = new BinaryReader(fs))
//         {
//             // Must read in SAME ORDER as written
//             string name1   = br.ReadString();
//             int    score1  = br.ReadInt32();
//             double gpa1    = br.ReadDouble();
//             bool   pass1   = br.ReadBoolean();
//  
//             Console.WriteLine($"{name1}: {score1} pts, GPA {gpa1}, Pass={pass1}");
//  
//             string name2   = br.ReadString();
//             int    score2  = br.ReadInt32();
//             double gpa2    = br.ReadDouble();
//             bool   pass2   = br.ReadBoolean();
//  
//             Console.WriteLine($"{name2}: {score2} pts, GPA {gpa2}, Pass={pass2}");
//         }
//  
//         // ── FileStream directly (raw bytes) ───────────────────
//         byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello Raw!");
//  
//         using (FileStream raw = new FileStream("raw.bin", FileMode.Create))
//         {
//             raw.Write(buffer, 0, buffer.Length);
//         }
//  
//         // Read back
//         using (FileStream raw = new FileStream("raw.bin", FileMode.Open))
//         {
//             byte[] readBack = new byte[raw.Length];
//             raw.Read(readBack, 0, readBack.Length);
//             Console.WriteLine(System.Text.Encoding.UTF8.GetString(readBack));
//         }
//     }
// }





// class DirectoryExamples
// {
//     static void Main()
//     { 
//         var path = "/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/output";
//         // ── Create directories ────────────────────────────────
//         Directory.CreateDirectory($"{path}");             // Creates if not exists
//         Directory.CreateDirectory($"{path}/reports/2026"); // Creates nested
//  
//         // ── Check if exists ───────────────────────────────────
//         if (Directory.Exists($"{path}"))
//             Console.WriteLine("output folder exists");
//  
//         // ── List files in a folder ─────────────────────────────
//         // Create some test files first
//         File.WriteAllText($"{path}/report1.txt", "Report 1");
//         File.WriteAllText($"{path}/report2.txt", "Report 2");
//         File.WriteAllText($"{path}/notes.md",    "Notes");
//  
//         // Get all files
//         string[] allFiles = Directory.GetFiles($"{path}");
//         Console.WriteLine("All files:");
//         foreach (string f in allFiles)
//             Console.WriteLine("  " + f);
//  
//         // Get files matching a pattern
//         string[] txtFiles = Directory.GetFiles($"{path}", "*.txt");
//         Console.WriteLine("TXT files:");
//         foreach (string f in txtFiles)
//             Console.WriteLine("  " + f);
//  
//         // Get files recursively (all subfolders too)
//         string[] allRecursive = Directory.GetFiles($"{path}", "*.*",
//             SearchOption.AllDirectories);
//  
//         // ── List subdirectories ───────────────────────────────
//         string[] subdirs = Directory.GetDirectories($"{path}");
//  
//         // ── Directory info ─────────────────────────────────────
//         DirectoryInfo di = new DirectoryInfo($"{path}");
//         Console.WriteLine($"Name:     {di.Name}");
//         Console.WriteLine($"Full:     {di.FullName}");
//         Console.WriteLine($"Parent:   {di.Parent?.Name}");
//         Console.WriteLine($"Created:  {di.CreationTime}");
//  
//         foreach (FileInfo fi in di.GetFiles())
//             Console.WriteLine($"  {fi.Name} ({fi.Length} bytes)");
//  
//         // ── Path utility ───────────────────────────────────────
//         string full     = Path.Combine($"{path}", "reports", "file.txt");
//         string dir      = Path.GetDirectoryName(full);   // output\reports
//         string filename = Path.GetFileName(full);        // file.txt
//         string noExt    = Path.GetFileNameWithoutExtension(full); // file 202604200859_HJHH.txt
//         string ext      = Path.GetExtension(full);       // .txt
//         string temp     = Path.GetTempPath();            // system temp
//  
//         Console.WriteLine(Path.Combine($"{path}", "sub", "file.txt"));
//  
//         // ── Copy directory (manual — no built-in CopyDirectory) ─
//         static void CopyDirectory(string source, string dest)
//         {
//             Directory.CreateDirectory(dest);
//             foreach (string file in Directory.GetFiles(source))
//                 File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
//             foreach (string subDir in Directory.GetDirectories(source))
//                 CopyDirectory(subDir, Path.Combine(dest, Path.GetFileName(subDir)));
//         }
//  
//         // Delete directory (and everything inside)
//         Directory.Delete($"{path}", recursive: true);
//     }
// }




//Reading & Writing CSV Files
//CSV (Comma Separated Values) is one of the most common file formats. No library needed — we can parse it manually.
// using System;
// using System.IO;
// using System.Collections.Generic;
// class CsvExamples
// {
//     record Student(string Name, int Age, double GPA);
//  
//     static void Main()
//     {
//         string csvPath = "/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/students.csv";
//  
//         // ── Write CSV ─────────────────────────────────────────
//         var students = new List<Student>
//         {
//             new ("Alice", 20, 3.9),
//             new ("Bob",   22, 3.5),
//             new ("Carol", 21, 3.7),
//         };
//         
//         using (var writer = new StreamWriter(csvPath))
//         {
//             writer.WriteLine("Name,Age,GPA");   // Header row
//             foreach (var s in students)
//                 writer.WriteLine($"{s.Name},{s.Age},{s.GPA}");
//         }
//  
//         // ── Read CSV ──────────────────────────────────────────
//         var loaded = new List<Student>();
//  
//         using (var reader = new StreamReader(csvPath))
//         {
//             string header = reader.ReadLine();  // Skip header
//             Console.WriteLine($"Headers: {header}");
//  
//             string line;
//             while ((line = reader.ReadLine()) != null)
//             {
//                 string[] parts = line.Split(',');
//                 loaded.Add(
//                     new Student(parts[0],
//                     int.Parse(parts[1]),
//                     double.Parse(parts[2])
//                 ));
//             }
//         }
//  
//         Console.WriteLine("\nLoaded students:");
//         foreach (var s in loaded)
//             Console.WriteLine($"  {s.Name}, Age {s.Age}, GPA {s.GPA}");
//  
//         // ── Using LINQ on CSV data ─────────────────────────────
//         var topStudents = loaded.Where(s => s.GPA >= 3.7).OrderByDescending(s => s.GPA);
//         Console.WriteLine("\nTop students (GPA >= 3.7):");
//         foreach (var s in topStudents)
//             Console.WriteLine($"  {s.Name}: {s.GPA}");
//     }
// }




//JSON Files — System.Text.Json
//JSON is the most popular data format today. C# has built-in JSON support via System.Text.Json (no NuGet needed in .NET 5+).
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Text.Json;
// using System.Text.Json.Serialization;
//
// // 1. Define the JSON Serializer Context
// // This static class tells the compiler what types to generate code for.
// [JsonSerializable(typeof(Person))]
// [JsonSerializable(typeof(List<Person>))]
// [JsonSerializable(typeof(Dictionary<string, object>))]
// public partial class CustomJsonContext : JsonSerializerContext
// {
// }
//
// // 2. Define the Model (Annotated)
// [JsonSerializable(typeof(Person))]
// public class Person
// {
//     // NOTE: The attribute on the class level handles all types within it.
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public string Email { get; set; }
//     public List<string> Hobbies { get; set; }
// }
//
// class JsonExamples
// {
//     static void Main()
//     {
//         // 3. Use the Generated Context
//         // We pass the CustomJsonContext, which directs the serializer to the
//         // optimized, pre-generated code, eliminating the reflection warning.
//         var options = new JsonSerializerOptions
//         {
//             WriteIndented = true,
//             // Specify the context to use the generated code
//             TypeInfoResolver = new CustomJsonContext() 
//         };
//
//         // ── Serialize (object → JSON string) ──────────────────
//         var person = new Person
//         {
//             Name    = "Alice",
//             Age     = 30,
//             Email   = "alice@example.com",
//             Hobbies = new List<string> { "Reading", "Coding", "Hiking" }
//         };
//
//         // NOTICE: We still use the option, but the warning is gone.
//         string json = JsonSerializer.Serialize(person, options);
//         Console.WriteLine("--- Single Person ---");
//         Console.WriteLine(json);
//
//         // ── Write JSON to file ────────────────────────────────
//         File.WriteAllText("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/person.json", json);
//
//         // ── Read JSON from file ───────────────────────────────
//         string loadedJson = File.ReadAllText("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/person.json");
//         
//         // We MUST use the options context here too!
//         Person loadedPerson = JsonSerializer.Deserialize<Person>(loadedJson, options);
//         Console.WriteLine($"Loaded: {loadedPerson.Name}, {loadedPerson.Age}");
//
//         // ── List of objects to/from JSON ──────────────────────
//         var people = new List<Person>
//         {
//             new Person { Name="Alice", Age=30, Email="alice@x.com", Hobbies=new(){"Reading"} },
//             new Person { Name="Bob",   Age=25, Email="bob@x.com",   Hobbies=new(){"Gaming"} },
//         };
//
//         string listJson = JsonSerializer.Serialize(people, options);
//         File.WriteAllText("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/people.json", listJson);
//
//         var loadedPeople = JsonSerializer.Deserialize<List<Person>>(
//             File.ReadAllText("/Users/rashiktuladhar/Desktop/c#/Practice/Day9Session/people.json"), options);
//
//         Console.WriteLine("\n--- List of People ---");
//         Console.WriteLine($"Loaded {loadedPeople.Count} people");
//     }
// }



/*
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

// =====================================================
// 1. THE STRUCTURE DEFINITION (The Model)
// =====================================================

// Level 2: The Student Object
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    
    // *** NESTED LIST ***
    // This is a list of strings (the courses)
    public List<string> EnrolledCourses { get; set; }
}

// Level 1: The Container (The list holding all students)
public class UniversityRoster
{
    // *** THE TOP-LEVEL LIST ***
    // This list holds multiple Student objects.
    public List<Student> Students { get; set; }
}

// =====================================================
// 2. JSON SERIALIZATION CONTEXT (For performance)
// =====================================================

// We must tell the serializer (the compiler) what types are nested.
// [JsonSerializable(typeof(UniversityRoster))]
// [JsonSerializable(typeof(Student))]
// public partial class LibraryContext : JsonSerializerContext
// {
//     // This context tells the serializer how to handle the nested types.
// }
//
// // =====================================================
// // 3. THE EXECUTION CODE
// // =====================================================
//
// class NestedListExample
// {
//     static void Main()
//     {
//         // 1. Initialize the structure
//         var roster = new UniversityRoster
//         {
//             Students = new List<Student>() // Start with an empty outer list
//         };
//
//         // 2. Create Student 1 (Student with 3 courses)
//         var student1 = new Student
//         {
//             StudentId = 1001,
//             Name = "Alice Johnson",
//             // Create the nested list of strings
//             EnrolledCourses = new List<string> { "Computer Science", "Calculus I", "English Literature" }
//         };
//
//         // 3. Create Student 2 (Student with 2 courses)
//         var student2 = new Student
//         {
//             StudentId = 1002,
//             Name = "Bob Smith",
//             // Create the nested list of strings
//             EnrolledCourses = new List<string> { "Biology", "Chemistry" }
//         };
//
//         // 4. Add the created objects to the outer list
//         roster.Students.Add(student1);
//         roster.Students.Add(student2);
//
//         // 5. Serialize the entire nested structure
//         var options = new JsonSerializerOptions
//         {
//             WriteIndented = true,
//             TypeInfoResolver = new LibraryContext() 
//         };
//
//         string json = JsonSerializer.Serialize(roster, options);
//         
//         Console.WriteLine("=================================================");
//         Console.WriteLine("=== Generated JSON Output (The Nested Data) ===");
//         Console.WriteLine("=================================================");
//         Console.WriteLine(json);
//     }
// }
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
1. Write a method that searches for a specific string across all .txt files in a folder and returns a list of the filenames that contain that string.
2. Write a method to compare two files line-by-line and return the exact line number where the first difference is found.
3. Write a program to read a CSV file containing "Product,Price" data and calculate the total sum of all prices.
4. Write a method that finds all files in a directory larger than 1MB and moves them into a new folder called "LargeFiles".
5. Write a program that renames all files in a folder by adding a prefix (like "Processed_") and a current date to the original filename.
*/
//Solution
/*
using System;
using System.Collections.Generic;
using System.IO; // Required for all File and Directory operations
using System.Linq;

namespace FileAssignmentSolution
{
    class Program
    {
        // We define a folder name. The program will create this folder automatically.
        static string folderPath = "StudentDataFolder";

        static void Main(string[] args)
        {
            // --- PREPARATION STEP ---
            // We call this first so that files exist before we try to read them.
            CreateSeedFiles();

            Console.WriteLine("=== File Operations Assignment ===\n");

            // 1. Search String
            Console.WriteLine("Task 1: Searching for 'Apple' in .txt files...");
            var results = SearchForString("Apple");
            Console.WriteLine("Files containing 'Apple': " + string.Join(", ", results));

            // 2. Compare Files
            Console.WriteLine("\nTask 2: Comparing file1.txt and file2.txt...");
            int diffLine = CompareFiles("file1.txt", "file2.txt");
            if (diffLine == -1) Console.WriteLine("Files are identical.");
            else Console.WriteLine($"First difference found on line: {diffLine}");

            // 3. CSV Sum
            Console.WriteLine("\nTask 3: Calculating total price from products.csv...");
            double total = SumCsvPrices("products.csv");
            Console.WriteLine($"Total Sum: ${total}");

            // 4. Move Large Files
            Console.WriteLine("\nTask 4: Moving files larger than 1MB to 'LargeFiles' folder...");
            MoveLargeFiles();
            Console.WriteLine("Movement complete.");

            // 5. Rename Files
            Console.WriteLine("\nTask 5: Renaming remaining files with prefix and date...");
            RenameFiles();
            Console.WriteLine("Renaming complete.");

            Console.WriteLine("\n--- All tasks finished. Check the 'StudentDataFolder' in your project folder! ---");
            Console.ReadKey();
        }

        /// <summary>
        /// This method creates the folder and seeds it with random data 
        /// so the students have files to work with immediately.
        /// </summary>
        static void CreateSeedFiles()
        {
            // If folder already exists, delete it to start fresh for the demonstration
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }

            // Create the main directory
            Directory.CreateDirectory(folderPath);

            // Seed File 1 (Contains 'Apple')
            File.WriteAllText(Path.Combine(folderPath, "file1.txt"), "Hello\nI love Apple juice\nGood day");

            // Seed File 2 (Different from File 1 on line 2)
            File.WriteAllText(Path.Combine(folderPath, "file2.txt"), "Hello\nI love Orange juice\nGood day");

            // Seed File 3 (Another .txt file without 'Apple')
            File.WriteAllText(Path.Combine(folderPath, "notes.txt"), "This is just a regular note.");

            // Seed CSV File (Product,Price)
            File.WriteAllText(Path.Combine(folderPath, "products.csv"), "Apple,1.50\nBanana,0.75\nMilk,3.20\nBread,2.10");

            // Seed a Large File (Approx 1.1 MB)
            // We create a byte array of 1.1 million bytes to ensure it's > 1MB
            byte[] largeData = new byte[1100000]; 
            File.WriteAllBytes(Path.Combine(folderPath, "bigfile.dat"), largeData);

            // Seed a Small File
            File.WriteAllText(Path.Combine(folderPath, "smallfile.txt"), "I am too small to move.");
            
            Console.WriteLine("System: Seed files created successfully.\n");
        }

        // 1. Method to search for a string across all .txt files
        static List<string> SearchForString(string word)
        {
            List<string> foundFiles = new List<string>();

            // Get only files ending in .txt
            string[] files = Directory.GetFiles(folderPath, "*.txt");

            foreach (string path in files)
            {
                // Read all text in the file
                string content = File.ReadAllText(path);

                // Check if word exists (ignoring case)
                if (content.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    // Add only the name of the file, not the full path
                    foundFiles.Add(Path.GetFileName(path));
                }
            }
            return foundFiles;
        }

        // 2. Method to compare two files line-by-line
        static int CompareFiles(string file1, string file2)
        {
            // Combine the folder path with the filename
            string path1 = Path.Combine(folderPath, file1);
            string path2 = Path.Combine(folderPath, file2);

            // Read lines into arrays
            string[] lines1 = File.ReadAllLines(path1);
            string[] lines2 = File.ReadAllLines(path2);

            // We compare up to the length of the shortest file to avoid errors
            int limit = Math.Min(lines1.Length, lines2.Length);

            for (int i = 0; i < limit; i++)
            {
                // If lines are different, return the line number (index + 1)
                if (lines1[i] != lines2[i])
                {
                    return i + 1;
                }
            }

            // If one file is longer than the other, that is also a difference
            if (lines1.Length != lines2.Length) return limit + 1;

            return -1; // No difference found
        }

        // 3. Method to sum prices in a CSV
        static double SumCsvPrices(string fileName)
        {
            double total = 0;
            string path = Path.Combine(folderPath, fileName);

            // Read all lines of the CSV
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                // Split the line by the comma (e.g. "Apple,1.50")
                string[] parts = line.Split(',');

                // Check if we actually have two parts (Product and Price)
                if (parts.Length == 2)
                {
                    // Try to convert the price string to a number
                    if (double.TryParse(parts[1], out double price))
                    {
                        total += price;
                    }
                }
            }
            return total;
        }

        // 4. Method to move files > 1MB
        static void MoveLargeFiles()
        {
            string targetDir = Path.Combine(folderPath, "LargeFiles");

            // Create the "LargeFiles" directory if it doesn't exist
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Get all files in the main folder
            string[] files = Directory.GetFiles(folderPath);

            foreach (string path in files)
            {
                // Use FileInfo to get the size in bytes
                FileInfo info = new FileInfo(path);

                // 1MB = 1024 * 1024 bytes
                if (info.Length > 1024 * 1024)
                {
                    string destination = Path.Combine(targetDir, info.Name);
                    File.Move(path, destination);
                }
            }
        }

        // 5. Method to rename files with prefix and date
        static void RenameFiles()
        {
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");
            string prefix = "Processed_";

            string[] files = Directory.GetFiles(folderPath);

            foreach (string path in files)
            {
                string fileName = Path.GetFileName(path);

                // Safety: Don't rename files that already have the prefix
                if (fileName.StartsWith(prefix)) continue;

                // Construct new name: Processed_2023-10-27_filename.txt
                string newName = $"{prefix}{dateStr}_{fileName}";
                string destination = Path.Combine(folderPath, newName);

                File.Move(path, destination);
            }
        }
    }
}
*/