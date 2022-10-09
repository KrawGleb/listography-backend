using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ITopicsRepository : IEFRepository<ListTopic>
{
    Task<ListTopic?> GetTopicByNameAsync(string name);
}