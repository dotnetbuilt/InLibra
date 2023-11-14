namespace InLibra.Service.DTOs.Books;

public class BookUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string About { get; set; }
    public int Pages { get; set; }
    public string Author { get; set; }
    public long LanguageId { get; set; }
    public long ShelfId { get; set; }
}