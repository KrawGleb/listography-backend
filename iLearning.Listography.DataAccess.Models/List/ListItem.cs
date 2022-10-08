using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class ListItem : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int UserListId { get; set; }
    [JsonIgnore]
    public UserList? UserList { get; set; }
}
