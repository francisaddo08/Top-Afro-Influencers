using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Model.Entities.Admin.Validators
{
    internal sealed class CreateAdminValidator : AbstractValidator<AdminUser>
    {
    public CreateAdminValidator() { 
     RuleFor(x => x.FirstName).NotNull();
      }
    }
}
