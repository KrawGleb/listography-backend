using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;
using iLearning.Listography.Application.Models.ViewModels.List;

namespace iLearning.Listography.Application.Common.Validation.Validators;

public class CustomFieldViewModelValidator : AbstractValidator<CustomFieldViewModel>
{
	public CustomFieldViewModelValidator()
	{
		RuleFor(vm => vm.StringValue)
			.MaximumLength(CustomFieldValidationRuleConstants.StringValueMaxLength);

		RuleFor(vm => vm.TextValue)
			.MaximumLength(CustomFieldValidationRuleConstants.TextValueMaxLength);
	}
}
