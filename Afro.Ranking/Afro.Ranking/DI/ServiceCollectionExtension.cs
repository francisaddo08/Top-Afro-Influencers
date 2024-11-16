using Afro.Ranking.Persistance.Repositories;

namespace Afro.Ranking.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection serviceCollection)
        {
            
                serviceCollection.AddScoped<InfluencerRepository>();
            return serviceCollection;
        }
    }
}
