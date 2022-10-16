using FluentValidation;

namespace iLearning.Listography.Application.Requests.Home.Queries.Get;

public class GetHomeInfoQueryValidator : AbstractValidator<GetHomeInfoQuery>
{
	public GetHomeInfoQueryValidator()
	{
		RuleFor(x => x.ItemsCount)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Items count cannot be less than zero");

		RuleFor(x => x.ListsCount)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Lists count cannot be less than zero");

		RuleFor(x => x.TagsCount)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Tags count cannot by less than zero");
	}
}
