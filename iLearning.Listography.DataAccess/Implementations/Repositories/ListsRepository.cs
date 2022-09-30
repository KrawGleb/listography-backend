using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

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
}
