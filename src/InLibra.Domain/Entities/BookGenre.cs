namespace InLibra.Domain.Entities;

public class BookGenre
{
    public long Id { get; set; }

    public long BookId { get; set; }
    public Book Book { get; set; }

    public long GenreId { get; set; }
    public Genre Genre { get; set; }
}