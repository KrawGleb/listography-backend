using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ITagsRepository : IEFRepository<ListTag>
{
    Task<IEnumerable<ListTag>> CreateTags(IEnumerable<ListTag> tags);
    void DeleteAll(IEnumerable<ListTag> tags);
}