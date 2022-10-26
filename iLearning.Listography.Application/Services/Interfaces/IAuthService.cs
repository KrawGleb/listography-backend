using iLearning.Listography.DataAccess.Models.Identity;

namespace iLearning.Listography.Application.Services.Interfaces;
public interface IAuthService
{
    Task<string> GenerateTokenAsync(ApplicationUser user);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
}