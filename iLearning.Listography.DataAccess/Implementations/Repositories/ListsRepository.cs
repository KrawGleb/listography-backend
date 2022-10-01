using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly ITagsRepository _tagsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        ITagsRepository tagsRepository) 
        : base(context)
    {
        _tagsRepository = tagsRepository;
    }

    public override async Task CreateAsync(UserList entity)
    {
        await _tagsRepository.CreateTags(entity.Tags);

        await base.CreateAsync(entity);
    }

    public override async Task<UserList?> GetByIdAsync(int id, bool trackEntity = false)
    {
        return await _table
            .Include(l => l.Items)
                .ThenInclude(i => i.CustomFields)
            .Include(l => l.ItemTemplate)
                .ThenInclude(t => t.CustomFields)
            .Include(l => l.Tags)
            .FirstAsync(l => l.Id == id);
    }
}
