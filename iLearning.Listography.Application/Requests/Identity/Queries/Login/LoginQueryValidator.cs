using FluentValidation;

namespace iLearning.Listography.Application.Requests.Identity.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull();

		RuleFor(x => x.Email)
			.EmailAddress();

		RuleFor(x => x.Password)
			.NotEmpty()
			.NotNull();
	}
}
