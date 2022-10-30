namespace iLearning.Listography.Infrastructure.Services.Interfaces;

public interface IUserPermissionsService
{
    Task<bool> AllowEditItemAsync(string userId, int itemId);
    Task<bool> AllowEditListAsync(string userId, int listId);
}