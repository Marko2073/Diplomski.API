using Diplomski.Application.Dto.Creates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Brand name must have at least 3 characters");
        }
    }
}
