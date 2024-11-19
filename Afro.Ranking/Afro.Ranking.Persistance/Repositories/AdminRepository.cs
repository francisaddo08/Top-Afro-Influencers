using Afro.Ranking.Domain.Model.Entities;

using Afro.Ranking.Domain.Model.Repository;
using Afro.Ranking.Persistance.Entities;
using Microsoft.AspNetCore.Identity;
using SharedKenel.Abstracts;
using SharedKenel.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance
{
    public class AdminRepository : Domain.Model.Repository.IAdminRepository
    {
    private readonly ApplicationContext _cxt;
    private readonly UserManager<Admin> _userManager;
    public AdminRepository(ApplicationContext context, UserManager<Admin> userManager)
    {  
       _cxt = context;
       _userManager = userManager;
     }

       

     
        

        public async Task<int> Save()
     {
       return await _cxt.SaveChangesAsync();
     }

        void IAdminRepository.Add(Domain.Model.Entities.Admin.Admin admin) => throw new NotImplementedException();
    }
}
