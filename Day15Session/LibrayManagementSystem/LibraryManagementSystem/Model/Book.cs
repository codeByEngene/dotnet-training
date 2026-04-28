using LibraryManagementSystem.Model.Shared;

namespace LibraryManagementSystem.Model;

/// <summary>
/// Represents a book in the library management system, including bibliographic details and inventory information.
/// </summary>
/// <remarks>The Book class encapsulates key metadata and tracking information for a library book, such as title,
/// author, publication details, and copy counts. It is typically used to manage and query book records within the
/// system.</remarks>
public class Book : LmsShared
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publication { get; set; }
    public string Category { get; set; }
    public string Edition { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string PublishedYear { get; set; }
    public string Isbn { get; set; }
    public int NoOfPages { get; set; }
    public string Status { get; set; }
}