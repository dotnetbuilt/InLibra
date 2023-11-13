using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface ILanguageRepository
{
    ValueTask CreateAsync(Language language);
    void Delete(Language language);
    ValueTask<Language> SelectByIdAsync(long languageId);
    IQueryable<Language> SelectAsync();
}