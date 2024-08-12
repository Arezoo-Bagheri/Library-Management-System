using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.Books.Commands.CreateBook;
using LibraryManagementSystem.Domain.Entities;
using Moq;

namespace Library_Management_System.Tests.Application.Commands.Books
{
    public class CreateBookCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldAddBookAndReturnBookId()
        {
            // Arrange
            var mock = new Mock<IApplicationUnitOfWork>();
            var handler = new CreateBookCommandHandler(mock.Object);

            var command = new CreateBookCommand
            {
                Title = "Test Title",
                Author = "Test Author",
                PublishedDate = DateTime.Now,
                CopiesAvailable = 10,
                IsAvailable = true
            };

            var bookId = 1;
            var book = new Book
            {
                Id = 0,
                Title = command.Title,
                Author = command.Author,
                PublishedDate = command.PublishedDate,
                CopiesAvailable = command.CopiesAvailable,
                IsAvailable = command.IsAvailable
            };

            mock.Setup(p => p.Books.AddAsync(It.IsAny<Book>()))
                                       .Callback<Book>(b =>
                                       {
                                           book = b;
                                           book.Id = bookId;
                                       })
                                       .Returns(Task.CompletedTask);

            mock.Setup(p => p.SaveChangesResult(It.IsAny<CancellationToken>()))
                                         .ReturnsAsync(1);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(bookId, result);
            Assert.Equal(command.Title, book.Title);
            Assert.Equal(command.Author, book.Author);
            Assert.Equal(command.PublishedDate, book.PublishedDate);
            Assert.Equal(command.CopiesAvailable, book.CopiesAvailable);
            Assert.Equal(command.IsAvailable, book.IsAvailable);
        }
    }
}
