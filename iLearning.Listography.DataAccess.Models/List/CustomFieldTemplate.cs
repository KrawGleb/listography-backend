using iLearning.Listography.DataAccess.Models.Helpers;
using iLearning.Listography.DataAccess.Models.Interfaces;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.List;

public class CustomFieldTemplate : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Order { get; set; }
    public CustomFieldType Type { get; set; }
    public ICollection<SelectOption>? SelectOptions { get; set; }

    [JsonIgnore]
    public ListItemTemplate? ListItemTemplate { get; set; }
    public int? ListItemTemplateId { get; set; }
}
