using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Afro.Ranking.Application.Admin
{
    public class Login
    {
          [EmailAddress]
        public required string UserId { get; set; }
        public required string Password { get; set; }
    }
    public class LoginResponse
    {
        public required string JwtToken { get; set; }
        public required DateTime ExpirationDate { get; set; }
    }


    public class LoginValidator : AbstractValidator<Login>
    {
      public LoginValidator()
      {
            RuleFor(x => x.UserId).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}