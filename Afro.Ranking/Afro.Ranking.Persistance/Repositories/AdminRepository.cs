using Afro.Ranking.Domain.Model.Entities;

using Afro.Ranking.Domain.Model.Repository;
using Afro.Ranking.Persistance.ADO.NET.Concrete;
using Afro.Ranking.Persistance.ADO.NET.ValueObjects;
using Afro.Ranking.Persistance.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedKenel.Abstracts;
using SharedKenel.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance
{
    public class AdminRepository :  Repository,  Domain.Model.Repository.IAdminRepository
    {
    private readonly ApplicationContext _cxt;
    private readonly UserManager<Admin> _userManager;
    
    public AdminRepository( 
                                                IOptions<List<ConnectionOptions>>  options,
                                                Logger<Repository> logger , 
                                                ApplicationContext context, 
                                                UserManager<Admin> userManager)
                                                :base(options, logger
                                                ) 
                                                {  
                                                   _cxt = context;
                                                   _userManager = userManager;
                                                 }

      
        public async Task<int> Save()
     {
       return await _cxt.SaveChangesAsync();
     }

        //void Add(Domain.Model.Entities.Admin.Admin admin) => throw new NotImplementedException();
        //void IAdminRepository.Add(Domain.Model.Entities.Admin.Admin admin) => throw new NotImplementedException();
    }
}
