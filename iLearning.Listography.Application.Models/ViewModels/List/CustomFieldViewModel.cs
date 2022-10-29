using iLearning.Listography.DataAccess.Models.Helpers;

namespace iLearning.Listography.Application.Models.ViewModels.List;

public class CustomFieldViewModel
{
    public string? Name { get; set; }
    public int Order { get; set; }
    public CustomFieldType Type { get; set; }
    public ICollection<SelectOptionViewModel>? SelectOptions { get; set; }

    public string? StringValue { get; set; }
    public string? TextValue { get; set; }
    public decimal? NumberValue { get; set; }
    public DateTime? DateTimeValue { get; set; }
    public bool? BoolValue { get; set; }
    public int? SelectValue { get; set; }
}
