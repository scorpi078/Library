using FluentValidation;
using Library.Models.Requests;

namespace Library.Validators
{
    public class BorrowingRequestValidatorcs : AbstractValidator<BorrowingRequest>
    {
        public BorrowingRequestValidatorcs()
        {
            RuleFor(bor => bor.Books).NotEmpty();
            RuleFor(bor => bor.Librarians).NotEmpty();
            RuleFor(bor => bor.Readers).NotEmpty();
            RuleFor(bor => bor.BorrowedDate).NotEmpty();
            RuleFor(bor => bor.ReturnDate).NotEmpty();
        }
    }
}
