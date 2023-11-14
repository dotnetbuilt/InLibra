using System.Linq.Expressions;
using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class GenreRepository:IGenreRepository
{
    private readonly InLibraContext _context;

    public GenreRepository(InLibraContext context)
    {
        _context = context;
    }

    public async ValueTask CreateAsync(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
    }

    public void Delete(Genre genre)
    {
        _context.Genres.Remove(genre);
        _context.SaveChanges();
    }

    public async ValueTask<Genre> SelectAsync(Expression<Func<Genre, bool>> expression = null, string[] includes = null)
    {
        var entities = 
            expression != null ? _context.Genres.AsQueryable() : _context.Genres.Where(expression).AsQueryable();
        
        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<Genre> SelectAll(Expression<Func<Genre, bool>> expression = null, string[] includes = null)
    {
        var entities = 
            expression != null ? _context.Genres.AsQueryable() : _context.Genres.Where(expression).AsQueryable();
        
        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }
}