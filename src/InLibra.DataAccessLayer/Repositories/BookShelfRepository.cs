using System.Linq.Expressions;
using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class BookShelfRepository:IBookShelfRepository
{
    private readonly InLibraContext _context;

    public BookShelfRepository(InLibraContext context)
    {
        _context = context;
    }

    public async ValueTask CreateAsync(BookShelf bookShelf)
    {
        await _context.AddAsync(entity: bookShelf);
        await _context.SaveChangesAsync();
    }

    public void Delete(BookShelf bookShelf)
    {
        _context.Remove(entity: bookShelf);
        _context.SaveChanges();
    }

    public async ValueTask<BookShelf> SelectAsync(Expression<Func<BookShelf, bool>> expression = null, string[] includes = null)
    {
        var entities = expression == null
            ? _context.BookShelves.AsQueryable()
            : _context.BookShelves.Where(expression).AsQueryable();
        
        if(includes != null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }
}