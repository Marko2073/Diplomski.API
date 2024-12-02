using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Specification;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Specification
{
    public class EfUpdateSpecificationCommand : EfUseCase, IUpdateSpecificationCommand
    {
        public UpdateSpecificationDtoValidator _validator;
        public EfUpdateSpecificationCommand(DatabaseContext context, UpdateSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update Specification";

        public string Description => "Update Specification";

        public void Execute(UpdateSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            var specification = Context.Specifications.Find(request.Id);

            if (specification == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Specification), request.Id.Value);
            }

            specification.Name = request.Name;
            specification.ParentId = request.ParentId;
            specification.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }

        
    }
    
}
