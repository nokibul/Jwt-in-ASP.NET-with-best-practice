using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agency.Configuration.Jwt
{
    public class JwtOptions
    {
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string Key { get; init; } = string.Empty;
    }
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JwtSettings").Get<JwtOptions>();
            services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    var key = Encoding.UTF8.GetBytes(jwtOptions.Key);
                    jwtBearerOptions.SaveToken = true;
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true
                    };
                });
            return services;
        }
    }
}
