using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Afro.Ranking.Persistance.Entities
{
    public class AdminUser: IdentityUser
    {
     public required string FirstName { get; set; }
     public required string LastName { get; set; }

    }
}
