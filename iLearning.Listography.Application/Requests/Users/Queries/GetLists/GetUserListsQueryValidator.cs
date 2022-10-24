using FluentValidation;

namespace iLearning.Listography.Application.Requests.Users.Queries.GetLists;

public class GetUserListsQueryValidator : AbstractValidator<GetUserListsQuery>
{
	public GetUserListsQueryValidator()
	{
		RuleFor(x => x.Username)
			.NotEmpty()
			.NotNull();
	}
}
