using FluentValidation;
using iLearning.Listography.DataAccess.Models.Constraints;

namespace iLearning.Listography.Application.Requests.Social.Commands.Comment;

public class CommentCommandValidator : AbstractValidator<CommentCommand>
{
    public CommentCommandValidator()
    {
        RuleFor(x => x.Content)
            .MaximumLength(CommentConstraints.TextMaxLength);
    }
}
