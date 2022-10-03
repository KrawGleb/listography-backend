using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Helpers.Extensions;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class CustomFieldsRepository : EFRepository<CustomField>, ICustomFieldsRepository
{
    public CustomFieldsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<IEnumerable<CustomField>> UpdateCustomFields(IEnumerable<CustomField> customFields)
    {
        var ids = customFields.Select(c => c.Id);
        var existingFields = customFields.Where(c => ids.Contains(c.Id));

        foreach (var field in existingFields)
        {
            var value = customFields.First(c => c.Id == field.Id).GetValue();
            field.SetValue(value);
        }

        await _context.SaveChangesAsync();
        return existingFields;
    }
}
