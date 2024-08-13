using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.Books.Commands.UpdateBook;
using LibraryManagementSystem.Domain.Entities;
using Moq;

namespace Library_Management_System.Tests.Application.Commands.Books
{
    public class UpdateBookCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldUpdateBookAndReturnTrue()
        {
            // Arrange
            var mock = new Mock<IApplicationUnitOfWork>();
            var handler = new UpdateBookCommandHandler(mock.Object);

            var command = new UpdateBookCommand
            {
                Id = 1,
                Title = "Update Title",
                Author = "Update Author",
                PublishedDate = DateTime.Now.AddYears(-1),
                CopiesAvailable = 5,
                IsAvailable = false
            };

            var book = new Book
            {
                Id = command.Id,
                Title = "Original Title",
                Author = "Original Author",
                PublishedDate = DateTime.Now.AddYears(-2),
                CopiesAvailable = 10,
                IsAvailable = true
            };

            mock.Setup(p => p.Books.GetByIdAsync(command.Id))
                                         .ReturnsAsync(book);

            mock.Setup(p => p.SaveChangesResult(It.IsAny<CancellationToken>()))
                                         .ReturnsAsync(1);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(command.Id, result);
            Assert.Equal(command.Title, book.Title);
            Assert.Equal(command.Author, book.Author);
            Assert.Equal(command.PublishedDate, book.PublishedDate);
            Assert.Equal(command.CopiesAvailable, book.CopiesAvailable);
            Assert.Equal(command.IsAvailable, book.IsAvailable);
        }

    }
}
