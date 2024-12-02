using Diplomski.Application.Dto.Creates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Role name must have at least 3 characters.");
        }
    }
}
