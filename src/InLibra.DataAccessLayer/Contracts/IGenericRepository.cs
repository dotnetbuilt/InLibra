using System.Linq.Expressions;
using InLibra.Domain.Commons;

namespace InLibra.DataAccessLayer.Contracts;

public interface IGenericRepository<TEntity> where TEntity:BaseModel
{
    ValueTask CreateAsync(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression=null, string[] includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
}