using Domain.DTO;
using FluentValidation;

namespace Application.Validators;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleSet("Create", () =>
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotEqual(" ")
                .WithMessage("First name is required.")
                .MinimumLength(3)
                .WithMessage("First name should be at least 3 characters long")
                .MaximumLength(100)
                .WithMessage("First name can't be more than 100 characters long");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotEqual(" ")
                .WithMessage("Last name is required.")
                .MinimumLength(3)
                .WithMessage("Last name should be at least 3 characters long")
                .MaximumLength(100)
                .WithMessage("Last name can't be more than 100 characters long");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotEqual(" ")
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .MinimumLength(5)
                .WithMessage("Email should be at least 5 characters long")
                .MaximumLength(100)
                .WithMessage("Email can't be more than 100 characters long");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotEqual(" ")
                .WithMessage("Password is required.")
                .Matches(@"[A-Z]+")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+")
                .WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W_]+")
                .WithMessage("Password must contain at least one special character.")
                .MinimumLength(8)
                .WithMessage("Password should be at least 8 characters long")
                .MaximumLength(100)
                .WithMessage("Password can't be more than 100 characters long");
        });
    }
}
