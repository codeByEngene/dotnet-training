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