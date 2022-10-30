using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Configurations;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iLearning.Listography.Application.Services.Implementatinos;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JWTConfiguration _jwtConfiguration;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        IOptions<JWTConfiguration> jwtConfiguration)
    {
        _userManager = userManager;
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException("User not found.");

        if (user.IsBlocked())
            throw new UserIsBlockedException("This user is blocked.");
        return user;
    }

    public async Task<string> GenerateTokenAsync(ApplicationUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Key);
        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Issuer = "ListographyBackend",
            Audience = "ListographyFrontent",
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
