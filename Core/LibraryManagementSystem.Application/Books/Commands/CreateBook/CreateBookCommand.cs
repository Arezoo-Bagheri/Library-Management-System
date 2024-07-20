using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CopiesAvailable { get; set; }
        public bool IsAvailable { get; set; }
    }

}
