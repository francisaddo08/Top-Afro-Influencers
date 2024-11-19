using Afro.Ranking.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Application.Admin
{
    public class AdminService
    {

        private readonly AdminRepository _adminRepositry;
        public AdminService(AdminRepository adminRepositry) 
      {
        _adminRepositry = adminRepositry;
      }
       public void Add(Domain.Model.Entities.Admin.Admin admin)
        {
            //Entities.Admin entity = new Entities.Admin()
            //{
            //    FirstName = admin.FirstName.Value,
            //    LastName = admin.LastName.Value,
            //    Email = admin.Email.Value,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //};
            //_adminRepositry.
       }

    }
}
