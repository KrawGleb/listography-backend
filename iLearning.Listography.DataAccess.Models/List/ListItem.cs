using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Models.List;

public class ListItem : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
}
