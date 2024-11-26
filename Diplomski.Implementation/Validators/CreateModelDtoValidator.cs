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
    public class CreateModelDtoValidator : AbstractValidator<CreateModelDto>
    {
        public CreateModelDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(3).WithMessage("Model name must have at least 3 characters");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");

            RuleFor(x => x.BrandId)
                .Must(x => context.Brands.Any(s => s.Id == x))
                .WithMessage("Brand with provided id doesn't exist or is invalid.");
            RuleFor(x => x.CategoryId)
                .Must(x => context.Categories.Any(s => s.Id == x))
                .WithMessage("Category with provided id doesn't exist or is invalid.");
        }
    }
}
