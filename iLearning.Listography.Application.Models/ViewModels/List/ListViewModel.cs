using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.ViewModels.List;

public class ListViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ListTopic? Topic { get; set; }
    public ListItemTemplate? ItemTemplate { get; set; }
    public ICollection<ItemViewModel>? Items { get; set; }
}
