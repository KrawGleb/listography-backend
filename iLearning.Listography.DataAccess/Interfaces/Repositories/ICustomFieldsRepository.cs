using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ICustomFieldsRepository : IEFRepository<CustomField>
{
    Task<IEnumerable<CustomField>> UpdateCustomFields(IEnumerable<CustomField> customFields);
}
