using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ItemsRepository : EFRepository<ListItem>, IItemsRepository
{
    private readonly ICustomFieldsRepository _customFieldsRepository;
    private readonly ITagsRepository _tagsRepository;

    public ItemsRepository(
        ApplicationDbContext context,
        ICustomFieldsRepository customFieldsRepository,
        ITagsRepository tagsRepository)
        : base(context)
    {
        _customFieldsRepository = customFieldsRepository;
        _tagsRepository = tagsRepository;
    }

    public async override Task<ListItem?> GetByIdAsync(int id, bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        var entity = await query
            .Include(i => i.CustomFields)
            .Include(i => i.Tags)
            .FirstOrDefaultAsync(i => i.Id == id);

        return entity;
    }

    public async override Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id, true);

        if (entity is not null)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(ListItem oldEntity, ListItem newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.CustomFields = (await _customFieldsRepository.UpdateCustomFields(newEntity.CustomFields)).ToList();

        _tagsRepository.DeleteAll(oldEntity.Tags);
        oldEntity.Tags = (await _tagsRepository.CreateTags(newEntity.Tags)).ToList();

        _context.Entry(oldEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
