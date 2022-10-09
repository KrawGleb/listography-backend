using iLearning.Listography.API.Filters;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.Application.Requests.Items.Commands.Delete;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using iLearning.Listography.Application.Requests.Items.Queries.Get;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] int id)
        => Ok(await Mediator.Send(new GetItemQuery { Id = id }));
}
