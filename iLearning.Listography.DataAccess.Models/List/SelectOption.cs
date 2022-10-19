using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class SelectOption : IEntity
{
    public int Id { get; set; }
    public int Value { get; set; }
    public string? Text { get; set; }

    [JsonIgnore]
    public CustomField? CustomField { get; set; }
    public int CustomFieldId { get; set; }
}
