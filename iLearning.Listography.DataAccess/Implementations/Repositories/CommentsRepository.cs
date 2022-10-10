using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class CommentsRepository : EFRepository<Comment>, ICommentsRespository
{
    public CommentsRepository(ApplicationDbContext context) 
        : base(context)
    { }
}
