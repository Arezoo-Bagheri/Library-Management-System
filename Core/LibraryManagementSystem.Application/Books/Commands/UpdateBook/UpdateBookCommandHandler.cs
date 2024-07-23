using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IApplicationUnitOfWork _uow;

        public UpdateBookCommandHandler(IApplicationUnitOfWork uow) => _uow = uow;


        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _uow.Books.GetByIdAsync(request.Id);

            if (book == null)
                throw new InvalidOperationException($"Book with Id {request.Id} was not found.");

            book.Title = request.Title;
            book.Author = request.Author;
            book.PublishedDate = request.PublishedDate;
            book.CopiesAvailable = request.CopiesAvailable;
            book.IsAvailable = request.IsAvailable;

            await _uow.Books.UpdateAsync(book);
            await _uow.SaveChangesResult(cancellationToken);


            return book.Id;

        }

    }
}
