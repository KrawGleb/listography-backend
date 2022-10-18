using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Update;

public class UpdateListInfoCommandValidator : AbstractValidator<UpdateListInfoCommand>
{
    public UpdateListInfoCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Title)
            .MaximumLength(ListValidationRulesConstants.MaxTitleLength);

        RuleFor(x => x.Description)
            .MaximumLength(ListValidationRulesConstants.MaxDescriptionLength);
    }
}
