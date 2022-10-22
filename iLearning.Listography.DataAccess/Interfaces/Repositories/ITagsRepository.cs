using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ITagsRepository : IEFRepository<ListTag>
{
    Task<IEnumerable<ListTag>> UpdateTagsAsync(IEnumerable<ListTag> oldTags, IEnumerable<ListTag> newTags, CancellationToken cancellationToken = default);
    Task<IEnumerable<ListTag>?> CreateTagsAsync(IEnumerable<ListTag>? tags, CancellationToken cancellationToken = default);
    Task<IEnumerable<ListTag>> GetRandomAsync(int count = 1, CancellationToken cancellationToken = default);
    Task DeleteAllAsync(IEnumerable<ListTag>? tags, CancellationToken cancellationToken = default);
}