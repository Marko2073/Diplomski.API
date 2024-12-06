using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.CategorySpecification;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.CategorySpecification
{
    public class EfCreateCategorySpecificationCommand : EfUseCase, ICreateCategorySpecificationCommand
    {
        public CreateCategorySpecificationDtoValidator _validator;
        public EfCreateCategorySpecificationCommand(DatabaseContext context, CreateCategorySpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 43;

        public string Name => "Create CategorySpecification";

        public string Description => "Create CategorySpecification";

        public void Execute(CreateCategorySpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            //uradi mi proveru da ne sme da postoji red u bazi koji vec ima ova dva id koji su stigli

            if (Context.CategorySpecifications.Any(x => x.CategoryId == request.CategoryId && x.SpecificationId == request.SpecificationId))
            {
                throw new ConflictException("Row already exist in database");
            }


            Context.CategorySpecifications.Add(new Domain.CategorySpecification
            {
                CategoryId = request.CategoryId,
                SpecificationId = request.SpecificationId
            });

            Context.SaveChanges();

            
        }
    }
}
