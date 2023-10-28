using Agency.Models.DTOs;

namespace Agency.Interfaces.IJwtService;
public interface IJwtService
{
    string GenerateToken(UserDataDTO user);
}