using FluentValidation;
using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;

namespace iLearning.Listography.Application.Requests.Identity.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull()
			.WithMessage("Email cannot be empty or null");

		RuleFor(x => x.Email)
			.EmailAddress()
			.WithMessage("Invalid email format");

		RuleFor(x => x.Username)
			.NotEmpty()
			.NotNull()
			.WithMessage("Username cannot be empty or null");

		RuleFor(x => x.Password)
			.NotEmpty()
			.NotNull()
			.WithMessage("Password cannot be empty or null");
	}
}
