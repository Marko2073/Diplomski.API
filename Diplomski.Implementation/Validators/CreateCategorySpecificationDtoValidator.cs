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
    public class CreateCategorySpecificationDtoValidator : AbstractValidator<CreateCategorySpecificationDto>
    {
        public DatabaseContext _context;
        public CreateCategorySpecificationDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.CategoryId)
                .Must(CategoryExists)
                .WithMessage("Category with an id of {PropertyValue} doesn't exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.SpecificationId)
                        .Must(SpecificationExists)
                        .WithMessage("Specification with an id of {PropertyValue} doesn't exist.");
                });




            

        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(x => x.Id == id);
        }

        public bool SpecificationExists(int id)
        {
            return _context.Specifications.Any(x => x.Id == id);
        }
    }
}
