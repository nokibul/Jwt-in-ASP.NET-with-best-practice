using Agency.Models.DTOs;

namespace Agency.Interfaces;
public interface IJwtService
{
    string GenerateToken(UserDataDTO user);
}