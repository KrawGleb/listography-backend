using iLearning.Listography.Application.Requests.List.Commands.AddItem;
using iLearning.Listography.Application.Requests.List.Commands.DeleteItem;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ApiControllerBase
{
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteItemCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddItemCommand command)
        => Ok(await Mediator.Send(command));
}
