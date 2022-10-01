using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class CustomFieldsRepository : EFRepository<CustomField>, ICustomFieldsRepository
{
    public CustomFieldsRepository(ApplicationDbContext context)
        : base(context)
    { }
}
