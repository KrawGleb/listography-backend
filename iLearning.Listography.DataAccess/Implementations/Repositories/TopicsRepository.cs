using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class TopicsRepository : EFRepository<ListTopic>, ITopicsRepository
{
    public TopicsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<ListTopic> GetTopicByNameAsync(string? name, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(name))
            return await GetDefaultTopicAsync();

        var topic = await _table
            .SingleOrDefaultAsync(t => t.Name!.ToLower() == name.ToLower(), cancellationToken);

        return topic ?? await GetDefaultTopicAsync();
    }

    private async Task<ListTopic> GetDefaultTopicAsync(CancellationToken cancellationToken = default)
    {
        return await _table
            .SingleAsync(t => t.Name!.ToLower() == "other", cancellationToken);
    }
}
