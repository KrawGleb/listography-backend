namespace iLearning.Listography.DataAccess.Models.List;

public class ListItemTemplate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
}
