using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;
using iLearning.Listography.Application.Requests.Identity.Queries.Login;
using iLearning.Listography.Application.Requests.Identity.Queries.LoginWithGoogle;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.Listography.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpPost("login-with-google")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] LoginWithGoogleQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
