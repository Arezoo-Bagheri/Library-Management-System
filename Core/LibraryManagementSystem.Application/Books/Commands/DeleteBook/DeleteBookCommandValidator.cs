using FluentValidation;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(u => u.Id)
                 .NotEmpty()
                 .WithMessage("this field is Required");
        }
    }
}
