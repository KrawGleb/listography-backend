using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.Responses.Identity;
using iLearning.Listography.Application.Requests.Identity.Queries.Login;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Identity.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IAuthService _authService;

    public LoginQueryHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IAuthService authService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authService = authService;
    }

    public async Task<Response> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserByEmailAsync(request.Email!);

        var signInResult = await _signInManager.PasswordSignInAsync(user?.UserName ?? "", request.Password, false, false);

        if (signInResult.Succeeded)
        {
            var token = await _authService.GenerateTokenAsync(user!);
            var isAdmin = await _userManager.IsInRoleAsync(user!, RolesEnum.Admin);

            return new LoginResponse()
            {
                Username = user!.UserName,
                Succeeded = true,
                Token = token,
                IsAdmin = isAdmin
            };
        }

        return new ErrorResponse() { Succeeded = false, Errors = new string[] { "Invalid password or email" } };
    }
}
