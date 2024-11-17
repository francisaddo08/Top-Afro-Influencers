using SharedKenel.Abstracts;
using SharedKenel.GUARD;
using SharedKenel.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Model.Entities
{
    public class Admin : Entity
    {
        public required FirstName FirstName { get; set; }
        public required string LastName { get; set; }
        private Admin( ) { }
        public static Admin Create(string firstName, string lastName)
        {
          
            Ensure.NotNullOrEmpty(firstName);
            Ensure.NotNullOrEmpty(lastName);
            FirstName f = FirstName.Create(firstName);
            Admin admin = new Admin(){ FirstName = f, LastName = lastName };
          return admin;
          
        }
    }
}
