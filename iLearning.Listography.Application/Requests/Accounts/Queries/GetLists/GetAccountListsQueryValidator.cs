using FluentValidation;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;

public class GetAccountListsQueryValidator : AbstractValidator<GetAccountListsQuery>
{
	public GetAccountListsQueryValidator()
	{
		RuleFor(x => x.Username)
			.NotEmpty()
			.NotNull();
	}
}
