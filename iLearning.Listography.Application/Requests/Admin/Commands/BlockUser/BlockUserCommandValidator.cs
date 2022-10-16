using FluentValidation;

namespace iLearning.Listography.Application.Requests.Admin.Commands.BlockUser;

public class BlockUserCommandValidator : AbstractValidator<BlockUserCommand>
{
	public BlockUserCommandValidator()
	{
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull();
    }
}
