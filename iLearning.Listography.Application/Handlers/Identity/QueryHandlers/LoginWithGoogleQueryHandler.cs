using Google.Apis.Auth;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.Responses.Identity;
using iLearning.Listography.Application.Requests.Identity.Queries.LoginWithGoogle;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Identity.QueryHandlers;

internal class LoginWithGoogleQueryHandler : IRequestHandler<LoginWithGoogleQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuthService _authService;

    public LoginWithGoogleQueryHandler(
        UserManager<ApplicationUser> userManager,
        IAuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    public async Task<Response> Handle(LoginWithGoogleQuery request, CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { "473094334857-1ds3b4m291i3pmpu6dpi63tu8167epo3.apps.googleusercontent.com" }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
        var user = await _userManager.FindByEmailAsync(payload.Email);

        return user is null
            ? await RegisterNewUser(payload)
            : await LoginExistingUserAsync(user);
    }

    private async Task<Response> RegisterNewUser(GoogleJsonWebSignature.Payload payload)
    {
        var user = new ApplicationUser()
        {
            UserName = payload.Email,
            Email = payload.Email
        };

        await _userManager.CreateAsync(user);

        return await LoginExistingUserAsync(user);
    }

    private async Task<Response> LoginExistingUserAsync(ApplicationUser user)
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
}
