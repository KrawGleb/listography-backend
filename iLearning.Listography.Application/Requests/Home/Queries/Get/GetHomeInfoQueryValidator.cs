using FluentValidation;

namespace iLearning.Listography.Application.Requests.Home.Queries.Get;

public class GetHomeInfoQueryValidator : AbstractValidator<GetHomeInfoQuery>
{
	public GetHomeInfoQueryValidator()
	{
		RuleFor(x => x.ItemsCount)
			.GreaterThanOrEqualTo(0);

		RuleFor(x => x.ListsCount)
			.GreaterThanOrEqualTo(0);

		RuleFor(x => x.TagsCount)
			.GreaterThanOrEqualTo(0);
	}
}
