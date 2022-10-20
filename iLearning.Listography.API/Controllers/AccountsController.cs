using iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;
using iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;
using iLearning.Listography.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ApiControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
        => Ok(await Mediator.Send(new GetMeQuery()
        {
            Id = HttpContext.GetUserId(),
        }));

    [HttpGet("{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAccountLists([FromRoute] string username)
        => Ok(await Mediator.Send(new GetAccountListsQuery()
        {
            Username = username
        }));
}
