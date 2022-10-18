using FluentValidation;
using iLearning.Listography.Application.Common.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Items.Commands.Update;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
	public UpdateItemCommandValidator()
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
