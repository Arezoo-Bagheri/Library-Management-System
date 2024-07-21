using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CopiesAvailable { get; set; }
        public bool IsAvailable { get; set; }
    }
}
