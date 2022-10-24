using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Create;

public class CreateListCommandValidator : AbstractValidator<CreateListCommand>
{
    public CreateListCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Title)
            .MaximumLength(ListValidationRulesConstants.TitleMaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(ListValidationRulesConstants.DescriptionMaxLength);
    }
}
