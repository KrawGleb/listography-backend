using FluentValidation;
using iLearning.Listography.Application.Common.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Items.Commands.Add;

public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
{
	public AddItemCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.NotNull();

		RuleFor(x => x.Tags)
			.Must(t => 
				t is null ||
				t.Count <= ItemValidationRulesConstants.TagsMaxCount)
			.WithMessage($"Tags max count is {ItemValidationRulesConstants.TagsMaxCount}");
	}
}
