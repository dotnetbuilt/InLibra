using InLibra.DataAccessLayer.Contracts;
using InLibra.DataAccessLayer.Repositories;
using InLibra.Domain.Entities;
using InLibra.Service.Interfaces;
using InLibra.Service.Mappers;
using InLibra.Service.Services;

namespace InLibra.WebApi.Extensions;

public static class ServiceCollection
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IAttachmentRepository, AttachmentRepository>();
        services.AddScoped<IBookGenreRepository, BookGenreRepository>();
        services.AddScoped<IBookShelfRepository, BookShelfRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
        services.AddScoped<IGenericRepository<Shelf>, GenericRepository<Shelf>>();
        
        //Services
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IBookGenreService, BookGenreService>();
        services.AddScoped<IBookShelfService, BookShelfService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IShelfService, ShelfService>();
        services.AddScoped<IUserService, UserService>();

        //Automapper
        services.AddAutoMapper(typeof(MappingProfile));
    }
}