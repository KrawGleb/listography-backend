using iLearning.Listography.Application.Requests.Tags.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TagsController : ApiControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
        => Ok(await Mediator.Send(new GetAllTagsQuery()));
}
