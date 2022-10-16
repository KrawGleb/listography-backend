using FluentValidation;

namespace iLearning.Listography.Application.Requests.Search.Queries.Search;

public class SearchQueryValidator : AbstractValidator<SearchQuery>
{
	public SearchQueryValidator()
	{
		RuleFor(x => x.SearchValue)
			.NotEmpty()
			.NotNull()
			.WithMessage("Search value cannot be null or empty");
	}
}
