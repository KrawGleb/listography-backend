using FluentValidation;

namespace iLearning.Listography.Application.Requests.Admin.Commands.UnblockUser;

public class UnblockUserCommandValidator : AbstractValidator<UnblockUserCommand>
{
	public UnblockUserCommandValidator()
	{
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull();
    }
}
