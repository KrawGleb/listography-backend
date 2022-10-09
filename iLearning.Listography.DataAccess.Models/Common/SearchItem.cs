using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Models.Common;

public class SearchItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? List { get; set; }
    public string? Author { get; set; }
    public IEnumerable<ListTag>? Tags { get; set; }
}
