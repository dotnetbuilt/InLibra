using System.Linq.Expressions;
using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IBookGenreRepository
{
    ValueTask CreateAsync(BookGenre bookGenre);
    void Delete(BookGenre bookGenre);
    ValueTask<BookGenre> SelectAsync(Expression<Func<BookGenre, bool>> expression = null, string[] includes = null);
}