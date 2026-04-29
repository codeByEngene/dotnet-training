namespace LibraryManagementSystem.Model.Report
{
    /// <summary>
    /// Represents filter criteria for generating borrowed books reports.
    /// </summary>
    /// <remarks>This class encapsulates various filter parameters used to narrow down the results when generating
    /// borrowed books reports. All properties are optional and can be used individually or in combination to filter results.</remarks>
    public class BorrowedReportFilter
    {
        /// <summary>
        /// Gets or sets the member ID to filter report results for a specific member.
        /// </summary>
        /// <remarks>If set, the report will only include books borrowed by this member.</remarks>
        public int MemberId { get; set; } 
        
        /// <summary>
        /// Gets or sets the book name to filter report results for a specific book title.
        /// </summary>
        /// <remarks>If set, the report will only include records for this book name.</remarks>
        public string BookName { get; set; } 
        
        /// <summary>
        /// Gets or sets the start date for filtering borrowed books report by a date range.
        /// </summary>
        /// <remarks>If set with ToDate, the report will include only records within this date range.</remarks>
        public DateOnly FromDate { get; set; } 
        
        /// <summary>
        /// Gets or sets the end date for filtering borrowed books report by a date range.
        /// </summary>
        /// <remarks>If set with FromDate, the report will include only records within this date range.</remarks>
        public DateOnly ToDate { get; set; } 
        
        /// <summary>
        /// Gets or sets the membership type to filter report results for members with a specific membership category.
        /// </summary>
        /// <remarks>If set, the report will only include records for members with this membership type.</remarks>
        public string MembershipType { get; set; }
    }
}
