using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class TopicsRepository : EFRepository<ListTopic>, ITopicsRepository
{
    public TopicsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<ListTopic> GetTopicByNameAsync(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return await GetDefaultTopic();

        var topic = await _table
            .SingleOrDefaultAsync(t => t.Name!.ToLower() == name.ToLower());

        return topic ?? await GetDefaultTopic();
    }

    private async Task<ListTopic> GetDefaultTopic()
    {
        return await _table
            .AsNoTracking()
            .SingleAsync(t => t.Name!.ToLower() == "other");
    }
}
