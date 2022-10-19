using iLearning.Listography.DataAccess.Models.Helpers;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.Common.List;

public class CustomFieldModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Order { get; set; }
    public CustomFieldType Type { get; set; }
    public ICollection<SelectOption>? SelectOptions { get; set; }

    public string? StringValue { get; set; }
    public string? TextValue { get; set; }
    public decimal? NumberValue { get; set; }
    public DateTime? DateTimeValue { get; set; }
    public bool? BoolValue { get; set; }
    public int? SelectValue { get; set; }
}
