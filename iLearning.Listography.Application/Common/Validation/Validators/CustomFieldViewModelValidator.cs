using FluentValidation;
using iLearning.Listography.Application.Models.ViewModels.List;
using iLearning.Listography.DataAccess.Models.Constraints;

namespace iLearning.Listography.Application.Common.Validation.Validators;

public class CustomFieldViewModelValidator : AbstractValidator<CustomFieldViewModel>
{
	public CustomFieldViewModelValidator()
	{
		RuleFor(vm => vm.StringValue)
			.MaximumLength(CustomFieldConstraints.StringMaxLength);

		RuleFor(vm => vm.TextValue)
			.MaximumLength(CustomFieldConstraints.TextMaxLength);
	}
}
