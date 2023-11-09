using Agency.Authentication.DTOs;

namespace Agency.Authentication.Interfaces;
public interface IJwtService
{
    string GenerateToken(UserDataDTO user);
}