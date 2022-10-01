using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Models.List;

public class UserList : IEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ListTopic? Topic { get; set; }
    public ListItem? ItemTemplate { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
    public ICollection<ListItem>? Items { get; set; }
}
