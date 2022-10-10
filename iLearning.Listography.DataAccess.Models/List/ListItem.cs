using iLearning.Listography.DataAccess.Models.Interfaces;
using Nest;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class ListItem : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Like>? Likes { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public UserList? UserList { get; set; }
    public int UserListId { get; set; }
}
