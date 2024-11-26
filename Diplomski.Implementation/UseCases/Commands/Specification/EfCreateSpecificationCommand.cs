using Diplomski.Application.Dto.Creates;
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
    public class EfCreateSpecificationCommand : EfUseCase, ICreateSpecificationCommand
    {
        public CreateSpecificationDtoValidator _validator;
        public EfCreateSpecificationCommand(DatabaseContext context, CreateSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Create Specification";

        public string Description => "Create Specification";

        public void Execute(CreateSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);
            
            Context.Specifications.Add(new Domain.Specification
            {
                Name = request.Name,
                ParentId = request.ParentId
            });

            Context.SaveChanges();


        }
    }
}
