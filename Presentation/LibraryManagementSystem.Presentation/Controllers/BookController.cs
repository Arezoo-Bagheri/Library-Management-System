using LibraryManagementSystem.Application.Books.Commands.CreateBook;
using LibraryManagementSystem.Application.Books.Commands.DeleteBook;
using LibraryManagementSystem.Application.Books.Commands.UpdateBook;
using LibraryManagementSystem.Application.Books.Queries.GetAllBooks;
using LibraryManagementSystem.Application.Books.Queries.GetBookById;
using LibraryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator) => _mediator = mediator;


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id in route and command do not match.");

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = new DeleteBookCommand { Id = id };

            await _mediator.Send(book);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById([FromQuery] int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = id });

            if (book == null)
                return NotFound();

            return Ok(book);
        }


        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var query = new GetAllBooksQuery();

            var books = await _mediator.Send(query);
            return Ok(books);
        }
    }

}
