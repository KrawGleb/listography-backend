namespace iLearning.Listography.DataAccess.Helpers.Options;

public class ListQueryOptions
{
    public int Id { get; set; }
    public bool Track { get; set; } = false;
    public bool IncludeItems { get; set; } = false;
    public bool IncludeItemTemplate { get; set; } = false;
    public bool IncludeTopic { get; set; } = false;
}
