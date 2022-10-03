using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Services.Implementatinos;

public class UserPermissionsService : IUserPermissionsService
{
    private readonly UserManager<Account> _userManager;
    private readonly IListsRepository _repository;

    public UserPermissionsService(
        UserManager<Account> userManager,
        IListsRepository repository)
    {
        _userManager = userManager;
        _repository = repository;
    }

    public async Task<bool> AllowEditListAsync(string userId, int listId)
    {
        var list = await _repository.GetByIdAsync(listId, trackEntity: false);

        if (list is not null &&
            list.AccountId == userId)
        {
            return true;
        }
        else
        {
            return await _userManager.IsInRoleAsync(
                    await _userManager.FindByIdAsync(userId), "admin");
        }
    }
}
