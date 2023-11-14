using InLibra.Domain.Enums;

namespace InLibra.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; }
}