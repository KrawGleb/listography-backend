using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class TopicsRepository : EFRepository<ListTopic>, ITopicsRepository
{
    public TopicsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<ListTopic?> GetTopicByNameAsync(string name)
    {
        return await _table.FirstOrDefaultAsync(t => t.Name!.ToLower() == name.ToLower()) 
            ?? await _table.FirstAsync(t => t.Name!.ToLower() == "other");
    }
}
