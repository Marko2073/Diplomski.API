using Diplomski.Application.Dto.Creates;
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
    public class EfCreateModelVersionSpecificationCommand : EfUseCase, ICreateModelVersionSpecificationCommand
    {
        public CreateModelVersionSpecificationDtoValidator _validator;
        public EfCreateModelVersionSpecificationCommand(DatabaseContext context, CreateModelVersionSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 48;

        public string Name => "Create ModelVersionSpecification";

        public string Description => "Create ModelVersionSpecification";

        public void Execute(CreateModelVersionSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.ModelVersionSpecifications.Add(new Domain.ModelVersionSpecification
            {
                ModelVersionId = request.ModelVersionId,
                SpecificationId = request.SpecificationId
            });

            Context.SaveChanges();

            
        }
    }
}
