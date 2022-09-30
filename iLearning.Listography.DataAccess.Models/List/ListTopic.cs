using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Models.List;

public class ListTopic : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
