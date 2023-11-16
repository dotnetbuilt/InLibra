namespace InLibra.Service.DTOs.Books;

public class BookCreationDto
{
    public string Title { get; set; }
    public string About { get; set; }
    public int Pages { get; set; }
    public string Author { get; set; }
    public long LanguageId { get; set; }
    public long AttachmentId { get; set; }
    public long UserId { get; set; }
}