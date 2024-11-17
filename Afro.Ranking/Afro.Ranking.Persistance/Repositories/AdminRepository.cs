using Afro.Ranking.Domain.Model.Entities;
using Afro.Ranking.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance
{
    public class AdminRepository : IAdminRepository
    {
    private readonly ApplicationContext _cxt;
    public AdminRepository(ApplicationContext context)
    {  
       _cxt = context;
     }

        public void Add(Admin admin)
        {
          Entities.Admin entity = new Entities.Admin(){ FirstName = admin.FirstName.Value, LastName = admin.LastName };
          _cxt.Admin.Add(entity);
        }

        public async Task<int> Save()
     {
       return await _cxt.SaveChangesAsync();
     }
    }
}
