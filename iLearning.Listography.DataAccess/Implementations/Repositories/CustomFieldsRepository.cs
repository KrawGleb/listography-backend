using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Helpers.Extensions;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class CustomFieldsRepository : EFRepository<CustomField>, ICustomFieldsRepository
{
    public CustomFieldsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<IEnumerable<CustomField>> UpdateCustomFieldsAsync(
        IEnumerable<CustomField> oldValues,
        IEnumerable<CustomField>? newValues, 
        CancellationToken cancellationToken = default)
    {
        if (oldValues is null || newValues is null)
            return Enumerable.Empty<CustomField>();

        if (oldValues.Count() != newValues.Count())
            throw new InvalidOperationException();

        for (int i = 0; i < oldValues.Count(); i++)
        {
            var newValue = newValues.ElementAt(i).GetValue();
            oldValues.ElementAt(i).SetValue(newValue);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return oldValues;
    }

    public async override Task AddRangeAsync(
        IEnumerable<CustomField>? entities,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entities);

        entities = entities.Select(entity =>
        {
            entity.Id = 0;

            entity.SelectOptions = entity.SelectOptions?.Select(option =>
            {
                option.Id = 0;
                return option;
            }).ToList();

            return entity;
        });

        await base.AddRangeAsync(entities, cancellationToken);
    }
}
