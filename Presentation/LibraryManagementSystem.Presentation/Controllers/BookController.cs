using LibraryManagementSystem.Application.Books.Commands.CreateBook;
using LibraryManagementSystem.Application.Books.Commands.UpdateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


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


    }
}
