using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ITagsRepository : IEFRepository<ListTag>
{
    Task<IEnumerable<ListTag>?> CreateTagsAsync(IEnumerable<ListTag>? tags);
    Task<IEnumerable<ListTag>> GetRandomAsync(int count);
    void DeleteAll(IEnumerable<ListTag>? tags);
}