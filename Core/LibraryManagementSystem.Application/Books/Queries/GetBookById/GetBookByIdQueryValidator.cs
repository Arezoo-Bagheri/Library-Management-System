using FluentValidation;

namespace LibraryManagementSystem.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("this field is Required");
        }
    }
}
