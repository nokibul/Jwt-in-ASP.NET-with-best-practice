using Agency.Authentication.Interfaces;
using Agency.Authentication.Services;

namespace Agency.Configuration.Service
{
    public static class ServiceRegistration
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
