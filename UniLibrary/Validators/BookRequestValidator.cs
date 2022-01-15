using FluentValidation;
using Library.Models.Requests;

namespace Library.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(b => b.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(b => b.AuthorName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(b => b.Category).IsInEnum();
        }
    }
}
