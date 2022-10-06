using iLearning.Listography.Application.Models.Configurations;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.Responses.Identity;
using iLearning.Listography.Application.Requests.Identity.Queries.Login;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iLearning.Listography.Application.Handlers.Identity.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
{
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;
    private readonly JWTConfiguration _jwtConfiguration;

    public LoginQueryHandler(
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IOptions<JWTConfiguration> jwtConfiguration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public async Task<Response> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var loginResult = await LoginAsync(request);

        if (loginResult.Succeeded)
        {
            var account = await _userManager.FindByEmailAsync(request.Email);
            var token = GenerateToken(account);
            var isAdmin = await _userManager.IsInRoleAsync(account, "admin");

            return new LoginResponse()
            {
                Succeeded = true,
                Token = token,
                IsAdmin = isAdmin
            };
        }

        return new ErrorResponse()
        {
            Succeeded = false,
            Errors = new string[] { "Invalid password or email" }
        };
    }

    private async Task<SignInResult> LoginAsync(LoginQuery request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

        return signInResult;
    }

    private string GenerateToken(Account account)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Key);

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, account.Id),
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", account.Id)
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescription);
        return jwtTokenHandler.WriteToken(token);
    }
}
