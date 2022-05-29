using CustomerApp.Contracts;
using FluentValidation;

namespace CustomerApp.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Fullname)
                .NotEmpty();

            RuleFor(x => x.EmailAddress)
                .NotEmpty();

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now.AddDays(1))
                .WithMessage("Your date of birth cannot be in the future");
        }
    }
}