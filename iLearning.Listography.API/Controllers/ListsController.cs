using iLearning.Listography.Application.Requests.List.Commands.AddItem;
using iLearning.Listography.Application.Requests.List.Commands.Create;
using iLearning.Listography.Application.Requests.List.Queries.Get;
using iLearning.Listography.Infrastructure.Extensions;
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
    {
        command.UserId = HttpContext.GetUserId();

        return Ok(await Mediator.Send(command));
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddItem([FromBody] AddItemCommand command)
        => Ok(await Mediator.Send(command));

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetList([FromRoute] int id)
        => Ok(await Mediator.Send(new GetListQuery { Id = id }));
}
