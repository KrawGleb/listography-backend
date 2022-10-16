using FluentValidation;
using iLearning.Listography.Application.Common.Validation.ValidationRulesConstants;

namespace iLearning.Listography.Application.Requests.Social.Commands.Comment;

public class CommentCommandValidator : AbstractValidator<CommentCommand>
{
	public CommentCommandValidator()
	{
		RuleFor(x => x.Content)
			.MaximumLength(CommentValidationRulesConstants.MaxContentLength)
			.WithMessage($"Comment content max length is {CommentValidationRulesConstants.MaxContentLength}");
	}
}
