using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Application.Admin
{
    public class AdminViewModel
    {
      public AdminViewModel(string firstName, string lastName , string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

         public required string FirstName { get;  set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
    }
    public class AdminUserViewModel
    {
        public AdminUserViewModel(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
    }
    public class CreateAdminUserViewModel
    {
        public CreateAdminUserViewModel(
                    string firstName, 
                    string lastName, 
                    string password,
                    string confirmPassword,
                    string email

                    )
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
        }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
