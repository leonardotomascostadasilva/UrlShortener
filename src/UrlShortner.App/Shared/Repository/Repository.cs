using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UrlShortner.App.Shared.Configuration;
using UrlShortner.App.Shared.Repository.Entities;
using UrlShortner.App.Shared.Repository.Interfaces;

namespace UrlShortner.App.Shared.Repository;
public class Repository : IRepository
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string code) where TEntity : Entity
    {
      var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        return entity;
    }

    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : Entity
    {
        _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
    }
}
