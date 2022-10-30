using FluentValidation;
using iLearning.Listography.DataAccess.Models.Constraints;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Create;

public class CreateListCommandValidator : AbstractValidator<CreateListCommand>
{
    public CreateListCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Title)
            .MaximumLength(UserListConstraints.TitleMaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(UserListConstraints.DescriptionMaxLength);
    }
}
