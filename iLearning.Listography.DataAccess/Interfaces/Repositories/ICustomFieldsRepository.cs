using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ICustomFieldsRepository : IEFRepository<CustomField>
{
    Task<IEnumerable<CustomField>> UpdateCustomFieldsAsync(
        IEnumerable<CustomField> oldValues,
        IEnumerable<CustomField>? newValues, 
        CancellationToken cancellationToken = default);
}
