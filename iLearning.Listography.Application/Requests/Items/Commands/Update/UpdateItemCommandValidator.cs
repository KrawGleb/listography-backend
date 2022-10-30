using FluentValidation;
using iLearning.Listography.DataAccess.Models.Constraints;

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
                t.Count <= ListItemConstraints.TagsMaxCount)
            .WithMessage($"Tags max count is {ListItemConstraints.TagsMaxCount}");
    }
}
