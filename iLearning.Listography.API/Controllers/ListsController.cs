using iLearning.Listography.API.Filters;
using iLearning.Listography.Application.Requests.List.Queries.Get;
using iLearning.Listography.Application.Requests.Lists.Commands.Create;
using iLearning.Listography.Application.Requests.Lists.Commands.Delete;
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

    [HttpPatch("update")]
    [ServiceFilter(typeof(ProtectedListActionFilter))]
    public async Task<IActionResult> UpdateListInfo([FromBody] UpdateListInfoCommand command)
        => Ok(await Mediator.Send(command));

    [HttpDelete("delete")]
    [ServiceFilter(typeof(ProtectedListActionFilter))]
    public async Task<IActionResult> DeleteList([FromBody] DeleteListCommand command)
        => Ok(await Mediator.Send(command));

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetList([FromRoute] int id)
        => Ok(await Mediator.Send(new GetListQuery { Id = id }));
}
