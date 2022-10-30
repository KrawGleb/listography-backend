using iLearning.Listography.Application.Common.Extensions;
using iLearning.Listography.Application.Requests.Users.Queries.GetLists;
using iLearning.Listography.Application.Requests.Users.Queries.GetMe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ApiControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetMeQuery()
        {
            Id = HttpContext.GetUserId(),
        }, cancellationToken));

    [HttpGet("{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserLists([FromRoute] string username, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetUserListsQuery()
        {
            Username = username
        }, cancellationToken));
}
