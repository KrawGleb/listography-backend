using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Services.Implementatinos;

public class UserPermissionsService
{
	private readonly UserManager<Account> _userManager;

	public UserPermissionsService(UserManager<Account> userManager)
	{
		_userManager = userManager;
	}

	public async Task<bool> AllowEditList(string userId, int listId)
	{
		var user = await _userManager
			.Users
			.Include(u => u.Lists)
			.FirstOrDefaultAsync(u => u.Id == userId);

		return
			user is not null && (
			user.Lists.Any(l => l.Id == listId) ||
			await IsAdmin(user));
	}

	private async Task<bool> IsAdmin(Account account)
	{
		return await _userManager.IsInRoleAsync(account,"admin");
	}
}
