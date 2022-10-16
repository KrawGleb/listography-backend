using FluentValidation;

namespace iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
	public DeleteUserCommandValidator()
	{
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull();
    }
}
