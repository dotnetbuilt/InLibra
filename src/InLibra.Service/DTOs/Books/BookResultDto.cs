using InLibra.Service.DTOs.Languages;
using InLibra.Service.DTOs.Shelves;
using InLibra.Service.DTOs.Users;

namespace InLibra.Service.DTOs.Books;

public class BookResultDto
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string About { get; set; }
    public int Pages { get; set; }
    public string Author { get; set; }
    public LanguageResultDto Language { get; set; }
    public ShelfResultDto Shelf { get; set; }
    public UserResultDto User { get; set; }
}