using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Models.Constants;

public static class TopicsEnum
{
    public static readonly IEnumerable<ListTopic> Topics = new List<ListTopic>
    {
        new() { Id = 1, Name = "Books" },
        new() { Id = 2, Name = "Animals" },
        new() { Id = 3, Name = "Movies" },
        new() { Id = 4, Name = "Locations" },
        new() { Id = 5, Name = "Persons" },
        new() { Id = 6, Name = "Games" },
        new() { Id = 7, Name = "Food" },
        new() { Id = 8, Name = "Other" },
    };
}
