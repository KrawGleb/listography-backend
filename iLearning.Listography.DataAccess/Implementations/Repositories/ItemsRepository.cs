using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ItemsRepository : EFRepository<ListItem>, IItemsRepository
{
    public ItemsRepository(ApplicationDbContext context)
        : base(context)
    { }
}
