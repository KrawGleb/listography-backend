using iLearning.Listography.Application.Requests.Social.Commands.AddLike;
using iLearning.Listography.Application.Requests.Social.Commands.Comment;
using iLearning.Listography.Application.Requests.Social.Commands.DeleteLike;
using iLearning.Listography.Application.Requests.Social.Queries.GetComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SocialController : ApiControllerBase
{
    [HttpPost("like")]
    public async Task<IActionResult> Like([FromBody] AddLikeCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost("dislike")]
    public async Task<IActionResult> Dislike([FromBody] DeleteLikeCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost("comment")]
    public async Task<IActionResult> Comment([FromBody] CommentCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [AllowAnonymous]
    [HttpGet("comments/{itemId}")]
    public async Task<IActionResult> GetComments([FromRoute] int itemId, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetCommentsQuery { ItemId = itemId }, cancellationToken));
}
