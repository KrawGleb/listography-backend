using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Helpers.DataSeeding;

public static class TopicsSeedingExtension
{
    public static void SeedWithTopics(this ModelBuilder builder)
    {
        builder
            .Entity<ListTopic>()
            .HasData(TopicsEnum.Topics);
    }
}
