using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Services.Implementatinos;

public class UserPermissionsService : IUserPermissionsService
{
    private readonly UserManager<Account> _userManager;
    private readonly IListsRepository _listsRepository;
    private readonly IItemsRepository _itemsRepository;

    public UserPermissionsService(
        UserManager<Account> userManager,
        IListsRepository listsRepository,
        IItemsRepository itemsRepository
        )
    {
        _userManager = userManager;
        _listsRepository = listsRepository;
        _itemsRepository = itemsRepository;
    }

    public async Task<bool> AllowEditItemAsync(string userId, int itemId)
    {
        var listId = await _itemsRepository.GetListIdAsync(itemId);

        return 
            listId is not null && 
            await AllowEditListAsync(userId, listId ?? -1);
    }

    public async Task<bool> AllowEditListAsync(string userId, int listId)
    {
        var ownerId = await _listsRepository.GetOwnerIdAsync(listId);

        var isUserListOwner = ownerId is not null &&
            ownerId == userId;

        var isUserAdmin = await _userManager.IsInRoleAsync(
            await _userManager.FindByIdAsync(userId), "admin");

        return isUserListOwner || isUserAdmin;
    }
}
