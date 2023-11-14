using System.Linq.Expressions;
using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface ILanguageRepository
{
    ValueTask CreateAsync(Language language);
    void Delete(Language language);
    ValueTask<Language> SelectAsync(Expression<Func<Language, bool>> expression = null, string[] includes = null);
    IQueryable<Language> SelectAll(Expression<Func<Language, bool>> expression = null, string[] includes = null);
}