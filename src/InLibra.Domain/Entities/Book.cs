using InLibra.Domain.Commons;

namespace InLibra.Domain.Entities;

public class Book:BaseModel
{
    public string Title { get; set; }
    public string About { get; set; }
    public int Pages { get; set; }
    public string Author { get; set; }

    public long LanguageId { get; set; }
    public Language Language { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<Genre> Genres { get; set; }
}