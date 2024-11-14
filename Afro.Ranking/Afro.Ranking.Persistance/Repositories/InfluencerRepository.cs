using Afro.Ranking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance.Repositories
{
    public class InfluencerRepository
    {
        private readonly ApplicationContext _context;
        public InfluencerRepository(ApplicationContext context) { _context = context; }
        public async Task<Influencer> GetInfluencerById(int id)
        {
            var result = await _context.Influencer
                                  .Include(x => x.YouTube)
                                  .Include(x => x.FaceBook)
                                  .Include(x => x.Twitter)
                                   .Include(x => x.IsInstagram)
                                  .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return new Influencer();
            }
            return result;
        }
        public Task<IQueryable<Influencer>> GetAll()
        {

            return (Task<IQueryable<Influencer>>)_context.Influencer
                                   .Include(x => x.YouTube)
                                   .Include(x => x.FaceBook)
                                   .Include(x => x.Twitter)
                                    .Include(x => x.IsInstagram)
                                   .AsQueryable();

        }
    }
}
