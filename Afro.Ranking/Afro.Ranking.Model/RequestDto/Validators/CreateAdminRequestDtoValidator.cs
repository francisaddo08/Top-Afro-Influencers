using FluentValidation;

namespace Afro.Ranking.Model.RequestDto.Validators
{
    public class CreateAdminRequestDtoValidator : AbstractValidator<CreateAdminRequestDto>
    {
      public CreateAdminRequestDtoValidator()
      {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cant not be Empty");
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cant not be Empty");

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).NotNull().WithMessage("Password cant not be Empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password Cant not be Empty");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password do not match");
        }

    }
}
