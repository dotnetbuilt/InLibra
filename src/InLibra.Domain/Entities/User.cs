using InLibra.Domain.Commons;
using InLibra.Domain.Enums;

namespace InLibra.Domain.Entities;

public class User:BaseModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
}