using System.Linq.Expressions;
using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:BaseModel
{
    private readonly InLibraContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(InLibraContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async ValueTask CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression = null,string[] includes = null)
    {
        var entities = 
            expression != null ? _dbSet.AsQueryable() : _dbSet.Where(expression).AsQueryable();
        
        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null,string[] includes = null)
    {
        var entities = 
            expression != null ? _dbSet.AsQueryable() : _dbSet.Where(expression).AsQueryable();
        
        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }
}