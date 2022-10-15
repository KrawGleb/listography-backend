using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class ListTag : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public ListItem? ListItem { get; set; }
    public int? ListItemId { get; set; }
}
