using LibraryManagementSystem.Application.Books.Commands.CreateBook;
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

    }
}
