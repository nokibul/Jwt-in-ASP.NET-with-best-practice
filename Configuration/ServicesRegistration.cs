using Agency.Member.Repositories;
using Agency.Agency.Repositories;
using Agency.Agency.Interfaces;
using Agency.Member.Interfaces;

namespace Agency.Configuration.Service
{
    public static class ServiceRegistration
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
