﻿using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IListsRepository : IEFRepository<UserList>
{
    Task AddItemToListAsync(int id, ListItem item);
}
