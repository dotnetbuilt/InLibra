using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IGenreRepository
{
    ValueTask CreateAsync(Genre genre);
    void Delete(Genre genre);
    ValueTask<Genre> SelectByIdAsync(long genreId);
    IQueryable<Genre> SelectAll();
}