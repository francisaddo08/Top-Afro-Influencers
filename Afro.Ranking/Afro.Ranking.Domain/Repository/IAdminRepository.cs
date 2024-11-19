
using Afro.Ranking.Domain.Model.Entities.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Model.Repository
{
    public interface IAdminRepository
    {
      
     void Add(Admin admin);
    }
}
