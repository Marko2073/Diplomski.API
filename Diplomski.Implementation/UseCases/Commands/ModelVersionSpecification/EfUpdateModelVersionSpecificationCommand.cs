using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.ModelVersionSpecification;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.ModelVersionSpecification
{
    public class EfUpdateModelVersionSpecificationCommand : EfUseCase, IUpdateModelVersionSpecificationCommand
    {
        public UpdateModelVersionSpecificationDtoValidator _validator;
        public EfUpdateModelVersionSpecificationCommand(DatabaseContext context, UpdateModelVersionSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 49;

        public string Name => "Update ModelVersionSpecification";

        public string Description => "Update ModelVersionSpecification";

        public void Execute(UpdateModelVersionSpecificationDto request)
        {

            _validator.ValidateAndThrow(request);

            var modelVersionSpecification = Context.ModelVersionSpecifications.Find(request.Id);

            if (modelVersionSpecification == null)
            {
                throw new EntityNotFoundException(nameof(ModelVersionSpecification), request.Id.Value);
            }

            modelVersionSpecification.ModelVersionId = request.ModelVersionId;
            modelVersionSpecification.SpecificationId = request.SpecificationId;

            Context.SaveChanges();
            
        }
    }
}
