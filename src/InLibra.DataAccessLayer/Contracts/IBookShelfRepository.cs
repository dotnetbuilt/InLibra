using System.Linq.Expressions;
using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IBookShelfRepository
{
    ValueTask CreateAsync(BookShelf bookShelf);
    void Delete(BookShelf bookShelf);
    ValueTask<BookShelf> SelectAsync(Expression<Func<BookShelf, bool>> expression = null, string[] includes = null);
}