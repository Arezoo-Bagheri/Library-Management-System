using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
