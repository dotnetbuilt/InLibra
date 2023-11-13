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

    public async ValueTask<Genre> SelectByIdAsync(long genreId)
        => await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);

    public IQueryable<Genre> SelectAll()
        => _context.Genres.AsQueryable();
}