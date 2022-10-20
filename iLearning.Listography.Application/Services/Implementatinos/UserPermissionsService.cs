using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Services.Implementatinos;

public class UserPermissionsService : IUserPermissionsService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IListsRepository _listsRepository;
    private readonly IItemsRepository _itemsRepository;

    public UserPermissionsService(
        UserManager<ApplicationUser> userManager,
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
        var user = await _userManager.FindByIdAsync(userId);
        var ownerId = await _listsRepository.GetOwnerIdAsync(listId);

        var isUserListOwner = ownerId == userId;
        var isUserAdmin = await _userManager.IsInRoleAsync(user, RolesEnum.Admin);

        return isUserListOwner || isUserAdmin;
    }
}
