using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;
public interface ITopicsRepository
{
    Task<ListTopic> GetTopicByNameAsync(string name);
}