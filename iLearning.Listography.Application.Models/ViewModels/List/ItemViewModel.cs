using iLearning.Listography.Application.Models.ViewModels.Common.List;

namespace iLearning.Listography.Application.Models.ViewModels.List;

public class ItemViewModel
{
    public int Id { get; set; }
    public int UserListId { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<CustomFieldViewModel>? CustomFields { get; set; }
    public ICollection<TagViewModel>? Tags { get; set; }
    public ICollection<CommentViewModel>? Comments { get; set; }

    public int TotalLikesCount { get; set; }
    public bool? Liked { get; set; }
}
