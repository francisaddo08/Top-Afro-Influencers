using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Application.Admin
{
    public class AdminViewModel
    {
      public AdminViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

         public required string FirstName { get;  set; }
        public required string LastName { get; set; }
    }
}
