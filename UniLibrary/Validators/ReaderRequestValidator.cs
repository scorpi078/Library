using FluentValidation;
using Library.Models.Requests;

namespace Library.Validators
{
    public class ReaderRequestValidator : AbstractValidator<ReaderRequest>
    {
        public ReaderRequestValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(b => b.PhoneNumber).NotNull().NotEmpty().GreaterThan(5).LessThan(11);
        }
    }
}
