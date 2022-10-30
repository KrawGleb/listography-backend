using FluentValidation;
using iLearning.Listography.DataAccess.Models.Constraints;

namespace iLearning.Listography.Application.Requests.Items.Commands.Add;

public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
{
	public AddItemCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.NotNull()
			.MaximumLength(ListItemConstraints.NameMaxLength);

		RuleFor(x => x.Tags)
			.Must(t => 
				t is null ||
				t.Count <= ListItemConstraints.TagsMaxCount)
			.WithMessage($"Tags max count is {ListItemConstraints.TagsMaxCount}");
	}
}
