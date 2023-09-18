using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using UrlShortner.App.Shared.Repository.Entities;
using UrlShortner.App.Shared.Repository.Interfaces;

namespace UrlShortner.App.Shared.Repository;

public class MemoryCacheRepository : IRepository
{
    private readonly Repository _decorated;
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheRepository(Repository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string code) where TEntity : Entity
    {
        string key = $"key-{code}";
        return await _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                return _decorated.FirstOrDefaultAsync(predicate, code);
            });
    }

    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : Entity
    {
       await _decorated.InsertAsync(entity);
    }
}
