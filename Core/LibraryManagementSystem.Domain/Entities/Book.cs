using LibraryManagementSystem.Domain.Common;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate {  get; set; }
        public int CopiesAvailable { get; set; }

        public ICollection <Loan> Loans { get; set; }
    }
}
