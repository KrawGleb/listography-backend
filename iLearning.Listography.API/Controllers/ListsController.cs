using iLearning.Listography.Application.Requests.List.Queries.Get;
using iLearning.Listography.Application.Requests.Lists.Commands.Create;
using iLearning.Listography.Application.Requests.Lists.Commands.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ListsController : ApiControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateList([FromBody] CreateListCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPost("update")]
    public async Task<IActionResult> UpdateListInfo([FromBody] UpdateListInfoCommand command)
        => Ok(await Mediator.Send(command));

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetList([FromRoute] int id)
        => Ok(await Mediator.Send(new GetListQuery { Id = id }));
}
