using iLearning.Listography.API.Hubs;
using iLearning.Listography.Application.Requests.Admin.Commands.Admin;
using iLearning.Listography.Application.Requests.Admin.Commands.BlockUser;
using iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;
using iLearning.Listography.Application.Requests.Admin.Commands.RemoveAdmin;
using iLearning.Listography.Application.Requests.Admin.Commands.UnblockUser;
using iLearning.Listography.Application.Requests.Admin.Queries.GetUserInfo;
using iLearning.Listography.DataAccess.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = RolesEnum.Admin)]
public class AdminsController : ApiControllerBase
{
    private readonly IHubContext<AppHub> _hubContext;

    public AdminsController(IHubContext<AppHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPatch("appoint")]
    public async Task<IActionResult> AppointAdmin([FromBody] AppointAdminCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPatch("unblock")]
    public async Task<IActionResult> UnblockUser([FromBody] UnblockUserCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserInfo([FromRoute] string username, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetUserInfoQuery { Username = username }, cancellationToken));

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await _hubContext.Clients.All.SendAsync("logout_user", command.Username, cancellationToken);
        return Ok(await Mediator.Send(command, cancellationToken));
    }


    [HttpPatch("remove")]
    public async Task<IActionResult> RemoveAdmin([FromBody] RemoveAdminCommand command, CancellationToken cancellationToken)
    {
        await _hubContext.Clients.All.SendAsync("logout_user", command.Username, cancellationToken);
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpPatch("block")]
    public async Task<IActionResult> BlockUser([FromBody] BlockUserCommand command, CancellationToken cancellationToken)
    {
        await _hubContext.Clients.All.SendAsync("logout_user", command.Username, cancellationToken);
        return Ok(await Mediator.Send(command, cancellationToken));
    }

}
