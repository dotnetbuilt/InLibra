using InLibra.Service.DTOs.Books;
using InLibra.Service.DTOs.Genres;

namespace InLibra.Service.DTOs.BookGenres;

public class BookGenreResultDto
{
    public long Id { get; set; }
    public BookResultDto Book { get; set; }
    public GenreResultDto Genre { get; set; }
}