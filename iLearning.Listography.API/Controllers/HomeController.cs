using iLearning.Listography.Application.Requests.Home.Queries.Get;
using Microsoft.AspNetCore.Mvc;


namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await Mediator.Send(new GetHomeInfoQuery()));
}
