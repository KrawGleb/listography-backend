using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;
public interface ITagsRepository
{
    Task<IEnumerable<ListTag>> CreateTags(IEnumerable<ListTag> tags);
}