namespace iLearning.Listography.Application.Services.Interfaces;

public interface IUserPermissionsService
{
    // TODO: Rename it.
    Task<bool> AllowEditListAsync(string userId, int listId);
}