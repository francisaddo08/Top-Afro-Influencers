using Afro.Ranking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance.Repositories
{
    public class InfluencerRepository : IDisposable, IInfluencerRepository
    {
        private readonly ApplicationContext _context;
        public InfluencerRepository(ApplicationContext context) { _context = context; }
        public static InfluencerRepository GetInstance()
        {
            ApplicationContext c = new();
            InfluencerRepository inst = new InfluencerRepository(c);
            return inst;
        }
        public async Task<Influencer> GetInfluencerById(int id)
        {
            var result = await _context.Influencer
                                  .Include(x => x.YouTube)
                                  .Include(x => x.FaceBook)
                                  .Include(x => x.Twitter)
                                   .Include(x => x.IsInstagram)
                                   .AsNoTracking()
                                  .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return new Influencer();
            }
            return result;
        }
        public async Task<List<Influencer>> GetAll()
        {

            return await _context.Influencer
                                   .Include(x => x.YouTube)
                                   .Include(x => x.FaceBook)
                                   .Include(x => x.Twitter)
                                    .Include(x => x.Instagram)
                                    .Include(x => x.TikTok)
                                   .ToListAsync();

        }

        public void Dispose()
        {

        }

        Task<IQueryable<Influencer>> IInfluencerRepository.GetAll() => throw new NotImplementedException();
    }
}
