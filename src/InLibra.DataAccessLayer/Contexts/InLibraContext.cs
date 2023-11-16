using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Contexts;

public class InLibraContext:DbContext
{
    public InLibraContext(DbContextOptions<InLibraContext> options):base(options)
    { }

    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<BookShelf> BookShelves { get; set; }
    public DbSet<User> Users { get; set; }
}