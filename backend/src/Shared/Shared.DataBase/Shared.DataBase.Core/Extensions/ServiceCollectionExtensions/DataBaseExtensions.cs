using Microsoft.Extensions.DependencyInjection;
using Shared.DataBase.Domain.Models;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.DataBase.Infrastructure.Services.DataBaseService;
using Shared.Domain.Models;

namespace Shared.DataBase.Core.Extensions.ServiceCollectionExtensions
{
    public static class DataBaseExtensions
    {
        public static IServiceCollection UseDataBase<TContext, TEntity, TId>
        (
            this IServiceCollection services
        ) 
        where TContext : DataBase<TEntity, TId>
        where TEntity : class, IBaseEntity<TEntity, TId>
        {
            services
                .AddScoped<IDataBaseRepository<TEntity, TId>, DataBaseRepository<TContext, TEntity, TId>>()
                .AddScoped<IDataBaseService<TEntity, TId>, DataBaseService<TEntity, TId>>();
            
            return services;
        }
    }
}