using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Configurations;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.Responses.Identity;
using iLearning.Listography.Application.Requests.Identity.Queries.Login;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iLearning.Listography.Application.Handlers.Identity.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JWTConfiguration _jwtConfiguration;

    public LoginQueryHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JWTConfiguration> jwtConfiguration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public async Task<Response> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserByEmailAsync(request.Email!);

        var signInResult = await _signInManager.PasswordSignInAsync(user?.UserName ?? "", request.Password, false, false);

        if (signInResult.Succeeded)
        {
            var token = await GenerateTokenAsync(user!);
            var isAdmin = await _userManager.IsInRoleAsync(user!, "admin");

            return new LoginResponse()
            {
                Succeeded = true,
                Token = token,
                IsAdmin = isAdmin
            };
        }

        return new ErrorResponse() { Succeeded = false, Errors = new string[] { "Invalid password or email" } };
    }

    private async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException("User not found.");

        if (user.IsBlocked())
            throw new UserIsBlockedException("This user is blocked.");

        return user;
    }

    private async Task<string> GenerateTokenAsync(ApplicationUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Key);
        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role ?? ""),
                new Claim("id", user.Id)
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescription);
        return jwtTokenHandler.WriteToken(token);
    }
}
