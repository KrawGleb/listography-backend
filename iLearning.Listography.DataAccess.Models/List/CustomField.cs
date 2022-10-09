using iLearning.Listography.DataAccess.Models.Helpers;
using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Models.List;

public class CustomField : IEntity
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
