using iLearning.Listography.Application.Requests.Admin.Commands.Admin;
using iLearning.Listography.Application.Requests.Admin.Commands.BlockUser;
using iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;
using iLearning.Listography.Application.Requests.Admin.Commands.RemoveAdmin;
using iLearning.Listography.Application.Requests.Admin.Commands.UnblockUser;
using iLearning.Listography.DataAccess.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = RolesEnum.Admin)]
public class AdminsController : ApiControllerBase
{
    [HttpPatch("appoint")]
    public async Task<IActionResult> AppointAdmin([FromBody] AppointAdminCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPatch("remove")]
    public async Task<IActionResult> RemoveAdmin([FromBody] RemoveAdminCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPatch("block")]
    public async Task<IActionResult> BlockUser([FromBody] BlockUserCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPatch("unblock")]
    public async Task<IActionResult> UnblockUser([FromBody] UnblockUserCommand command)
        => Ok(await Mediator.Send(command));

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        => Ok(await Mediator.Send(command));
}
