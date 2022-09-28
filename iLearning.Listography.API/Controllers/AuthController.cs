using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;
using iLearning.Listography.Application.Requests.Identity.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        => Ok(await Mediator.Send(command));

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
        => Ok(await Mediator.Send(query));
}
