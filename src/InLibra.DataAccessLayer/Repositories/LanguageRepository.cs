using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class LanguageRepository:ILanguageRepository
{
    private readonly InLibraContext _context;

    public LanguageRepository(InLibraContext context)
    {
        _context = context;
    }

    public async ValueTask CreateAsync(Language language)
    {
        await _context.Languages.AddAsync(language);
        await _context.SaveChangesAsync();
    }

    public void Delete(Language language)
    {
        _context.Languages.Remove(language);
        _context.SaveChanges();
    }

    public async ValueTask<Language> SelectByIdAsync(long languageId)
        => await _context.Languages.FirstOrDefaultAsync(language => language.Id == languageId);

    public IQueryable<Language> SelectAsync()
        => _context.Languages.AsQueryable();
}