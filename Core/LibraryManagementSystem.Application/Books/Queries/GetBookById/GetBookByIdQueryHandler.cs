using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IApplicationUnitOfWork _uow;

        public GetBookByIdQueryHandler(IApplicationUnitOfWork uow) => _uow = uow;


        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _uow.Books.GetByIdAsync(request.Id);
            return book;
        }
    }
}
