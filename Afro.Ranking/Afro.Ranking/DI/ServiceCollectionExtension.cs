using Afro.Ranking.Domain.Model.Repository;
using Afro.Ranking.Persistance;
using Afro.Ranking.Persistance.Repositories;

namespace Afro.Ranking.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection serviceCollection)
        {
            
                serviceCollection.AddScoped<InfluencerRepository>();
            serviceCollection.AddScoped<AdminRepository>();
            return serviceCollection;
        }
    }
}
