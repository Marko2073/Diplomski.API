using Diplomski.Application.Dto.Creates;
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
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public CreateCategoryDtoValidator _validator;
        public EfCreateCategoryCommand(DatabaseContext context, CreateCategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create Category";

        public string Description => "Create Category";

        public void Execute(CreateCategoryDto request)
        {
            _validator.ValidateAndThrow(request);


            Context.Categories.Add(new Domain.Category
            {
                Name = request.Name,
                ParentId = request.ParentId
            });

            Context.SaveChanges();


        }
    }
}
