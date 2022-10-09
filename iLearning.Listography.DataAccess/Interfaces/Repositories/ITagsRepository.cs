using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ITagsRepository : IEFRepository<ListTag>
{
    Task<IEnumerable<ListTag>> UpdateTagsAsync(IEnumerable<ListTag> oldTags, IEnumerable<ListTag> newTags);
    Task<IEnumerable<ListTag>?> CreateTagsAsync(IEnumerable<ListTag>? tags);
    Task<IEnumerable<ListTag>> GetRandomAsync(int count);
    Task DeleteAll(IEnumerable<ListTag>? tags);
}