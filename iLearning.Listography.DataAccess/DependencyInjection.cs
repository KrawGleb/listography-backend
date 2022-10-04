using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Implementations.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.Listography.DataAccess;

public static class DependencyInjection
{
    // TODO: Rename or split it.
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Secure connection string.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Default"), 
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

        services.AddIdentity<Account, IdentityRole>(options => { })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IListsRepository, ListsRepository>();
        services.AddScoped<ITagsRepository, TagsRepository>();
        services.AddScoped<ICustomFieldsRepository, CustomFieldsRepository>();
        services.AddScoped<ITopicsRepository, TopicsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();

        return services;
    }
}
