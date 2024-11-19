using SharedKenel.Abstracts;
using SharedKenel.GUARD;
using SharedKenel.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Model.Entities.Admin
{
    public class Admin : Entity
    {
        public required FirstName FirstName { get; set; }
        public required LastName LastName { get; set; }
        public required Password Password { get; set; }
        public required Password ConfirmPassword { get; set; }
        public required Email Email { get; set; }
        private Admin( ) { }
        public static Admin Create(string firstName, string lastName, string email, string password )
        {
          
            Ensure.NotNullOrEmpty(firstName);
            Ensure.NotNullOrEmpty(lastName);
            FirstName f = FirstName.Create(firstName);
            LastName l = LastName.Create(lastName);
            Email e = Email.Create(email);
            Password p = Password.Create(password);
            Password pw = Password.Create(password);
            Admin admin = new Admin(){ Id = Guid.NewGuid(), FirstName = f, LastName = l, Password = p, Email = e, ConfirmPassword = pw };
          return admin;
          
        }
    }
    public class AdminUser : Entity
    {
        public AdminUser(
                    string firstName,
                    string lastName,
                    string password,
                    string confirmPassword,
                    string email

                    )
        {
             FirstName = FirstName.Create(firstName);
            LastName = LastName.Create(lastName);
            Password = Password.Create(password);
            Email = Email.Create(email);
           
           
        }
       
        public required FirstName FirstName { get; set; }
        public required LastName LastName { get; set; }
        public required Password Password { get; set; }
        public required Password ConfirmPassword { get; set; }
        public required Email Email { get; set; }
    }
}
