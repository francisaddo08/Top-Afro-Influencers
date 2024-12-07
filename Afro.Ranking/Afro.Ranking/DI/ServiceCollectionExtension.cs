using Afro.Ranking.Domain.Model.Repository;
using Afro.Ranking.Persistance;
using Afro.Ranking.Persistance.Repositories;

namespace Afro.Ranking.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection service)
        {
           
            service.AddScoped<InfluencerRepository>();
            service.AddScoped<IAdminRepository,  AdminRepository>();

            return service;
        }
    }
}
