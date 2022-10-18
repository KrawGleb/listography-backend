using FluentValidation;
using iLearning.Listography.Application.Requests.Admin.Commands.Admin;

namespace iLearning.Listography.Application.Requests.Admin.Commands.AppointAdmin;

public class AppointAdminCommandValidator : AbstractValidator<AppointAdminCommand>
{
	public AppointAdminCommandValidator()
	{
		RuleFor(x => x.Username)
			.NotEmpty()
			.NotNull();
	}
}
