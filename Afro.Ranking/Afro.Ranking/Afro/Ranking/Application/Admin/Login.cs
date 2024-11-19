using FluentValidation;

namespace Afro.Ranking.Application.Admin
{
    public class Login
    {
        public required string UserId { get; set; }
        public required string Password { get; set; }
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