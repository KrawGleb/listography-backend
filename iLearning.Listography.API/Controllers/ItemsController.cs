using iLearning.Listography.API.Filters;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.Application.Requests.Items.Commands.Delete;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ApiControllerBase
{
    [HttpPost("create")]
    [ServiceFilter(typeof(ProtectedListActionFilter))]
    public async Task<IActionResult> Create([FromBody] AddItemCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPatch("update")]
    [ServiceFilter(typeof(ProtectedItemActionFilter))]
    public async Task<IActionResult> Update([FromBody] UpdateItemCommand command)
        => Ok(await Mediator.Send(command));

    [HttpDelete("delete")]
    [ServiceFilter(typeof(ProtectedItemActionFilter))]
    public async Task<IActionResult> Delete([FromBody] DeleteItemCommand command)
        => Ok(await Mediator.Send(command));
}
