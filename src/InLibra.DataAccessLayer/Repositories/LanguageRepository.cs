using System.Linq.Expressions;
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

    public async ValueTask<Language> SelectAsync(Expression<Func<Language, bool>> expression = null, string[] includes = null)
    {
        var languages = expression == null
            ? _context.Languages.AsQueryable()
            : _context.Languages.Where(expression).AsQueryable();
        
        if(includes != null)
            foreach (var include in includes)
                languages = languages.Include(include);

        return await languages.FirstOrDefaultAsync();
    }

    public IQueryable<Language> SelectAll(Expression<Func<Language, bool>> expression = null, string[] includes = null)
    {
        var languages = expression == null
            ? _context.Languages.AsQueryable()
            : _context.Languages.Where(expression).AsQueryable();
        
        if(includes != null)
            foreach (var include in includes)
                languages = languages.Include(include);

        return languages;
    }
}