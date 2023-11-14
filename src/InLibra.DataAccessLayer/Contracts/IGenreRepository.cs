using System.Linq.Expressions;
using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IGenreRepository
{
    ValueTask CreateAsync(Genre genre);
    void Delete(Genre genre);
    ValueTask<Genre> SelectAsync(Expression<Func<Genre, bool>> expression = null, string[] includes = null);
    IQueryable<Genre> SelectAll(Expression<Func<Genre, bool>> expression = null, string[] includes = null);
}