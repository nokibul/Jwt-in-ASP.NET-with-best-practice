using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Agency.Interfaces.IJwtService;
using Agency.Models.DTOs;
using Agency.Models.Entities.Jwt;

namespace Agency.Services.Authentication.Jwt;

public sealed class JwtService : IJwtService
{
    private readonly JwtOptions _options;

    public JwtService(IOptions<JwtOptions> options)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public string GenerateToken(UserDataDTO? user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var key = Encoding.ASCII.GetBytes(_options.Key);
        var securityKey = new SymmetricSecurityKey(key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                // new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}