using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IItemsRepository : IEFRepository<ListItem>
{
    Task UpdateAsync(ListItem oldEntity, ListItem newEntity);
}
