using InLibra.Service.DTOs.Books;
using InLibra.Service.DTOs.Shelves;

namespace InLibra.Service.DTOs.BookShelves;

public class BookShelfResultDto
{
    public long Id { get; set; }
    public BookResultDto Book { get; set; }
    public ShelfResultDto Shelf { get; set; }
}