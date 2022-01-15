using FluentValidation;
using Library.Models.Requests;


namespace Library.Validators
{
    public class LibrarianRequestValidator : AbstractValidator<LibrarianRequest>
    {
        public LibrarianRequestValidator()
        {
            RuleFor(l => l.Name).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
