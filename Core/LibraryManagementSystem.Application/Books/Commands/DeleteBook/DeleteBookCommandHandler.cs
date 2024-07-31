using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IApplicationUnitOfWork _uow;
        public DeleteBookCommandHandler(IApplicationUnitOfWork uow) => _uow = uow;


        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _uow.Books.GetByIdAsync(request.Id);

            if (book == null)
                throw new InvalidOperationException($"Book with Id {request.Id} not found.");

            await _uow.Books.RemoveAsync(book);
            await _uow.SaveChangesResult(cancellationToken);
            return book.Id;
        }
    }

}
