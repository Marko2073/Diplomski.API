using Diplomski.Application.Dto.Creates;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class CreateSpecificationDtoValidator : AbstractValidator<CreateSpecificationDto>
    {
        public CreateSpecificationDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).Must((dto, name) => !context.Specifications.Any(s => s.Name == name && s.ParentId == dto.ParentId)).WithMessage("Specification with the same name and parent already exists");
            RuleFor(x => x.ParentId).Must(id => id==null || context.Specifications.Any(s => s.Id == id)).WithMessage("Parent with the specified id does not exist");
        }
    }
}
