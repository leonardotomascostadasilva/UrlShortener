using System.Linq.Expressions;
using UrlShortner.App.Shared.Repository.Entities;

namespace UrlShortner.App.Shared.Repository.Interfaces;
public interface IRepository
{
    Task InsertAsync<TEntity>(TEntity entity) where TEntity : Entity;
    Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity;
}
