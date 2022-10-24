using FluentValidation;

namespace iLearning.Listography.Application.Requests.Users.Queries.GetMe;

public class GetMeQueryValidator : AbstractValidator<GetMeQuery>
{
	public GetMeQueryValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.NotNull();
	}
}
