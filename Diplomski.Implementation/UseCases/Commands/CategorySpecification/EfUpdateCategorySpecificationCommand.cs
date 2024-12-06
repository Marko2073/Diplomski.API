using Diplomski.Application.Dto.Updates;
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
    public class EfUpdateCategorySpecificationCommand : EfUseCase, IUpdateCategorySpecificationCommand
    {
        public UpdateCategorySpecificationDtoValidator _validator;
        public EfUpdateCategorySpecificationCommand(DatabaseContext context, UpdateCategorySpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 44;

        public string Name => "Update CategorySpecification";

        public string Description => "Update CategorySpecification";

        public void Execute(UpdateCategorySpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            var catspec = Context.CategorySpecifications.Find(request.Id);
            if(catspec==null)
            {
                throw new EntityNotFoundException(nameof(Domain.CategorySpecification), request.Id.Value);
            }

            if(Context.CategorySpecifications.Any(x => x.CategoryId == request.CategoryId && x.SpecificationId == request.SpecificationId))
            {
                throw new ConflictException("Row already exist in database");
            }

            catspec.CategoryId = request.CategoryId;
            catspec.SpecificationId = request.SpecificationId;

            Context.SaveChanges();

            
            
        }
    }
}
