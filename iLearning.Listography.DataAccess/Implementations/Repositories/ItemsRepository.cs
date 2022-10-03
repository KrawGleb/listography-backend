using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ItemsRepository : EFRepository<ListItem>, IItemsRepository
{
    private readonly ICustomFieldsRepository _customFieldsRepository;

    public ItemsRepository(
        ApplicationDbContext context,
        ICustomFieldsRepository customFieldsRepository)
        : base(context)
    {
        _customFieldsRepository = customFieldsRepository;
    }

    public async override Task UpdateAsync(ListItem entity)
    {
        var existingItem = await GetByIdAsync(entity.Id);

        existingItem.Name = entity.Name;
        await _customFieldsRepository.UpdateCustomFields(entity.CustomFields);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ListItem oldEntity, ListItem newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.CustomFields = (await _customFieldsRepository.UpdateCustomFields(newEntity.CustomFields)).ToList();

        _context.Entry(oldEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

}
