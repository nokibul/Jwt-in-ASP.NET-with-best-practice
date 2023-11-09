namespace Agency.Authentication.Utils;
public class AuthenticationUtil
{
    public static string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }
}
