using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery: IRequest<List<Book>>
    {
    }
}
