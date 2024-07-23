using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IApplicationUnitOfWork _uow;

        public CreateBookCommandHandler(IApplicationUnitOfWork uow) => _uow = uow;


        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PublishedDate = request.PublishedDate,
                CopiesAvailable = request.CopiesAvailable,
                IsAvailable = request.IsAvailable
            };

            await _uow.Books.AddAsync(book);
            await _uow.SaveChangesResult(cancellationToken);
            return book.Id;
        }

    }
}
