using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class UserList : IEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ListTopic? Topic { get; set; }
    public ListItemTemplate? ItemTemplate { get; set; }
    public ICollection<ListItem>? Items { get; set; }

    [JsonIgnore]
    public Account? Account { get; set; }
    public string? AccountId { get; set; }
}
