using FluentValidation;

namespace LibraryManagementSystem.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                    .NotEmpty().WithMessage("this field is required")
                    .MaximumLength(200).WithMessage("title must be less than 200");

            RuleFor(b => b.Author)
                 .NotEmpty().WithMessage("this field is required")
                 .MaximumLength(100).WithMessage("author must be less than 100");

            RuleFor(b => b.CopiesAvailable)
                .GreaterThan(0).WithMessage("Copies available must be greater than 0")
                .LessThanOrEqualTo(1000).WithMessage("Copies available must be less than or equal to 1000");

            RuleFor(b => b.IsAvailable)
                .NotNull().WithMessage("this field is required");

            RuleFor(b => b.PublishedDate)
                .NotEmpty().WithMessage("this field is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Published date cannot be in the future");
        }


    }
}
