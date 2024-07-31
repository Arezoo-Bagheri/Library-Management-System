using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IApplicationUnitOfWork _uow;
        public GetAllBooksQueryHandler(IApplicationUnitOfWork uow) => _uow = uow;


        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.Books.GetAllAsync();
            return books.ToList();
        }

    }
}
