namespace InLibra.Service.Helpers;

public static class PasswordHasher
{
    public static string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(string hashedPassword, string currenPassword)
        => BCrypt.Net.BCrypt.Verify(currenPassword, hashedPassword);
}