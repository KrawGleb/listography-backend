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
    public async Task<IActionResult> Create([FromBody] AddItemCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPatch("update")]
    [ServiceFilter(typeof(ProtectedItemActionFilter))]
    public async Task<IActionResult> Update([FromBody] UpdateItemCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpDelete("delete")]
    [ServiceFilter(typeof(ProtectedItemActionFilter))]
    public async Task<IActionResult> Delete([FromBody] DeleteItemCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetItemQuery { Id = id }, cancellationToken));
}
