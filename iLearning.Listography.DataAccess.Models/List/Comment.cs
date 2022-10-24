using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class Comment : IEntity
{
    public int Id { get; set; }
    public string? Text { get; set; }

    [JsonIgnore]
    public ListItem? ListItem { get; set; }
    public int? ListItemId { get; set; }

    [JsonIgnore]
    public ApplicationUser? ApplicationUser { get; set; }
    public string? ApplicationUserId { get; set; }
}
