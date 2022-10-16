using FluentValidation;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;

public class GetMeQueryValidator : AbstractValidator<GetMeQuery>
{
	public GetMeQueryValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.NotNull();
	}
}
