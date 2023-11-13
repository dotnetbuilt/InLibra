using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IBookGenreRepository
{
    ValueTask CreateAsync(BookGenre bookGenre);
    void Delete(BookGenre bookGenre);
}