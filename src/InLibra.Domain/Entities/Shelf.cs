using InLibra.Domain.Commons;

namespace InLibra.Domain.Entities;

public class Shelf:BaseModel
{
    public string Name { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }    
}

