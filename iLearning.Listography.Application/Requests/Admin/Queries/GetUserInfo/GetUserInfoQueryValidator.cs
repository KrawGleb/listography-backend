using FluentValidation;

namespace iLearning.Listography.Application.Requests.Admin.Queries.GetUserInfo;

public class GetUserInfoQueryValidator : AbstractValidator<GetUserInfoQuery>
{
	public GetUserInfoQueryValidator()
	{
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .WithMessage("Username cannot be empty or null");
    }
}
