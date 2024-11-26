using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Category
{
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        public UpdateCategoryDtoValidator _validator;

        public EfUpdateCategoryCommand(DatabaseContext context, UpdateCategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update Category";

        public string Description => "Update Category";

        public void Execute(UpdateCategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = Context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Category), request.Id.Value);
            }

            category.Name = request.Name;
            category.ParentId = request.ParentId;

            Context.SaveChanges();

        }
    }
}
