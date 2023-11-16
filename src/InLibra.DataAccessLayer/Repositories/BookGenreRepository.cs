using System.Linq.Expressions;
using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class BookGenreRepository:IBookGenreRepository
{
    private readonly InLibraContext _context;

    public BookGenreRepository(InLibraContext context)
    {
        _context = context;
    }

    public async ValueTask CreateAsync(BookGenre bookGenre)
    {
        await _context.BookGenres.AddAsync(bookGenre);
        await _context.SaveChangesAsync();
    }

    public void Delete(BookGenre bookGenre)
    {
        _context.BookGenres.Remove(bookGenre);
        _context.SaveChanges();
    }

    public async ValueTask<BookGenre> SelectAsync(Expression<Func<BookGenre, bool>> expression = null, string[] includes = null)
    {
        var entities = expression == null
            ? _context.BookGenres.AsQueryable()
            : _context.BookGenres.Where(expression).AsQueryable();
        
        if(includes != null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }
}