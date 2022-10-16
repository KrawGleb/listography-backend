using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Create;

public class CreateListCommandValidator : AbstractValidator<CreateListCommand>
{
	public CreateListCommandValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.NotNull()
			.WithMessage("Title cannot be empty or null");

		RuleFor(x => x.Title)
			.MaximumLength(ListValidationRulesConstants.MaxTitleLength)
			.WithMessage($"Title max length is {ListValidationRulesConstants.MaxTitleLength}");

		RuleFor(x => x.Description)
			.MaximumLength(ListValidationRulesConstants.MaxDescriptionLength)
			.WithMessage($"Description max length is {ListValidationRulesConstants.MaxDescriptionLength}");
	}
}
