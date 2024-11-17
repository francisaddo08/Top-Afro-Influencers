using  Afro.Ranking.Persistance.Entities;

namespace Afro.Ranking.Persistance.Repositories
{
    public interface IInfluencerRepository
    {
        Task<IQueryable<Influencer>> GetAll();
        Task<Influencer> GetInfluencerById(int id);
    }
}