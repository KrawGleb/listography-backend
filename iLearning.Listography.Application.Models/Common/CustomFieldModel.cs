using iLearning.Listography.DataAccess.Models.Helpers;

namespace iLearning.Listography.Application.Models.Common;

public class CustomFieldModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Order { get; set; }
    public CustomFieldType Type { get; set; }

    public string? StringValue { get; set; }
    public string? TextValue { get; set; }
    public int? IntValue { get; set; }
    public DateTime? DateTimeValue { get; set; }
    public bool? BoolValue { get; set; }
}
