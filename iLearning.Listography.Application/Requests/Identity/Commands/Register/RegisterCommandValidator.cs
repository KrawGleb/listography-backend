using FluentValidation;
using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;

namespace iLearning.Listography.Application.Requests.Identity.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull();

		RuleFor(x => x.Email)
			.EmailAddress();

		RuleFor(x => x.Username)
			.NotEmpty()
			.NotNull();

		RuleFor(x => x.Password)
			.NotEmpty()
			.NotNull();
	}
}
