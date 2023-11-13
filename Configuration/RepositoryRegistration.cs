using Agency.Member.Repositories;
using Agency.Agency.Repositories;
using Agency.Agency.Interfaces;
using Agency.Member.Interfaces;

namespace Agency.Configuration.Repository
{
    public static class RepositoryRegistration
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
