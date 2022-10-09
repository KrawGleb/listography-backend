using iLearning.Listography.Application.Requests.Search.Queries.Search;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ApiControllerBase
{
    [HttpGet("{value}")]
    public async Task<IActionResult> Get([FromRoute] string value)
        => Ok(await Mediator.Send(new SearchQuery { SearchValue = value }));
}
