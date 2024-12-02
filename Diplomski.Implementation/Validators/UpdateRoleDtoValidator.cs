using Diplomski.Application.Dto.Updates;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Role name must have at least 3 characters.");

            RuleFor(x => x.Name)
                .Must((dto, name) => !context.Roles.Any(r => r.Name == name && r.Id != dto.Id))
                .WithMessage("Role name must be unique.");
            


        }
    }
}
