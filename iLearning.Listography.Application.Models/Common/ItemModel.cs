using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.Common;

public class ItemModel
{
    public int Id { get; set; }
    public int UserListId { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
    public ICollection<CommentModel>? Comments { get; set; }

    public int TotalLikesCount { get; set; }
    public bool? Liked { get; set; }
}
