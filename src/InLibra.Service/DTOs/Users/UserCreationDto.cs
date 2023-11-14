using InLibra.Domain.Enums;

namespace InLibra.Service.DTOs.Users;

public class UserCreationDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}