using FluentValidation;

namespace iLearning.Listography.Application.Requests.Admin.Commands.RemoveAdmin;

public class RemoveAdminCommandValidator : AbstractValidator<RemoveAdminCommand>
{
    public RemoveAdminCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .WithMessage("Username cannot be empty or null");
    }
}
