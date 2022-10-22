using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Common.Validation.Validators;

public class TagValidator : AbstractValidator<ListTag>
{
	public TagValidator()
	{
		RuleFor(t => t.Name)
			.MaximumLength(TagValidationRules.TagMaxLength);
	}
}
