namespace iLearning.Listography.Application.Services.Interfaces;

public interface IUserPermissionsService
{
    Task<bool> AllowEditListAsync(string userId, int listId);
}