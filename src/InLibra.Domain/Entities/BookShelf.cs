namespace InLibra.Domain.Entities;

public class BookShelf
{
    public long Id { get; set; }
    
    public long ShelfId { get; set; }
    public Shelf Shelf { get; set; }

    public long BookId { get; set; }
    public Book Book { get; set; }
}