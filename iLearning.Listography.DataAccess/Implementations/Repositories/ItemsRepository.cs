﻿using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

    public async override Task CreateAsync(ListItem entity)
    {
        entity.CreatedAt = DateTime.Now;
        await base.CreateAsync(entity);
    }

    public async override Task<ListItem?> GetByIdAsync(int id, bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        var entity = await query
            .Include(i => i.CustomFields)
            .Include(i => i.Tags)
            .SingleAsync(i => i.Id == id);

        return entity;
    }

    public async Task<int?> GetListIdAsync(int id)
    {
        return (await _table.FirstOrDefaultAsync(i => i.Id == id))?.UserListId;
    }

    public async Task<IEnumerable<ListItem>> GetLastCreated(int count)
    {
        var query = _table
            .Include(i => i.UserList)
                .ThenInclude(l => l.Account)
            .AsNoTracking()
            .OrderByDescending(i => i.CreatedAt)
            .Take(count);

        return await query.ToListAsync();
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
        var customFields = await _customFieldsRepository.UpdateCustomFieldsAsync(newEntity.CustomFields);
        var tags = await _tagsRepository.CreateTagsAsync(newEntity.Tags);

        _tagsRepository.DeleteAll(oldEntity.Tags);
        oldEntity.Tags = tags?.ToList();
        oldEntity.Name = newEntity.Name;
        oldEntity.CustomFields = customFields.ToList();

        _context.Entry(oldEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
