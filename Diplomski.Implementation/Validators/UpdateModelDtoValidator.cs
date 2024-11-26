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
    public class UpdateModelDtoValidator : AbstractValidator<UpdateModelDto>
    {
        //napisi mi pravilo da brand id i categoryid moraju da postoje u bazi, i da id mora biti prosledjen, i da name mora biti duzi od 3 karaktera
        public UpdateModelDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Model name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Model name must have at least 3 characters");

            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();

            RuleFor(x => x.BrandId)
                .Must(x => context.Brands.Any(s => s.Id == x))
                .WithMessage("Brand with provided id doesn't exist or is invalid.");
            RuleFor(x => x.CategoryId)
                .Must(x => context.Categories.Any(s => s.Id == x))
                .WithMessage("Category with provided id doesn't exist or is invalid.");

        }
    }
}
