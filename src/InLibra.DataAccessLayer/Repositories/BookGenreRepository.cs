using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;

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
}