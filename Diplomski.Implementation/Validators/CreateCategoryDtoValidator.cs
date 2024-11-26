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
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Category name must have at least 3 characters");

            RuleFor(x => x.ParentId)
               .Must(x => x == null || context.Categories.Any(s => s.Id == x))
               .WithMessage("Parent specification with provided id doesn't exist or is invalid.");
        }
    }
}
