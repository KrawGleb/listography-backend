using FluentValidation;

namespace iLearning.Listography.Application.Requests.Identity.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull()
			.WithMessage("Email cannot be null or empty");

		RuleFor(x => x.Email)
			.EmailAddress()
			.WithMessage("Invalid email format");

		RuleFor(x => x.Password)
			.NotEmpty()
			.NotNull()
			.WithMessage("Password cannot be null or empty");
	}
}
