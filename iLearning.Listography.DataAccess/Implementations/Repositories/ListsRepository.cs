﻿using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly IItemsRepository _itemsRepository;
    private readonly ITopicsRepository _topicsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        IItemsRepository itemsRepository,
        ITopicsRepository topicsRepository)
        : base(context)
    {
        _itemsRepository = itemsRepository;
        _topicsRepository = topicsRepository;
    }

    public async Task<UserList?> GetByIdAsync(
        int id,
        bool includeItems = true,
        bool includeItemTemplate = true,
        bool includeTopic = true,
        bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        query = includeItems
            ? query
                .Include(l => l.Items!)
                    .ThenInclude(i => i.CustomFields)!
                    .ThenInclude(f => f.SelectOptions)
                .Include(l => l.Items!).ThenInclude(i => i.Tags)
            : query;

        query = includeItemTemplate
            ? query
                .Include(l => l.ItemTemplate!)
                    .ThenInclude(i => i.CustomFields)!
                    .ThenInclude(f => f.SelectOptions)
            : query;

        query = includeTopic
            ? query.Include(l => l.Topic)
            : query;

        return await query.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<string?> GetOwnerIdAsync(int listId)
    {
        var entity = await _table
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == listId);

        return entity?.ApplicationUserId;
    }

    public async Task<IEnumerable<UserList>> GetLargestAsync(int count)
    {
        return await _table
            .AsNoTracking()
            .Include(l => l.Items)
            .OrderByDescending(l => l.Items.Count)
            .Take(count)
            .ToListAsync();
    }

    public async Task UpdateAsync(UserList entity)
    {
        var existingList = await GetByIdAsync(
            entity.Id,
            includeItems: false,
            includeItemTemplate: false,
            trackEntity: true)
        ?? throw new InvalidOperationException();

        await ApplyFieldsChangesAsync(existingList, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ListItem> AddItemToListAsync(int id, ListItem item)
    {
        var list = await GetByIdAsync(id, trackEntity: true)
            ?? throw new InvalidOperationException();

        await _itemsRepository.CreateAsync(item);


        list.Items!.Add(item);

        await _context.SaveChangesAsync();

        return item;
    }

    private async Task ApplyFieldsChangesAsync(UserList oldEntity, UserList newEntity)
    {
        oldEntity.Title = newEntity.Title;
        oldEntity.Description = newEntity.Description;
        oldEntity.ImageUrl = newEntity.ImageUrl;
        oldEntity.Topic = await _topicsRepository.GetTopicByNameAsync(newEntity.Topic?.Name!);
    }
}
