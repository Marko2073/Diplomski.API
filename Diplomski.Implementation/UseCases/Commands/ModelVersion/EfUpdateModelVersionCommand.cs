using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.ModelVersion
{
    public class EfUpdateModelVersionCommand : EfUseCase, IUpdateModelVersionCommand
    {
        public UpdateModelVersionDtoValidator _validator;
        public EfUpdateModelVersionCommand(DatabaseContext context, UpdateModelVersionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Update ModelVersion";

        public string Description => "Update ModelVersion";

        public void Execute(UpdateModelVersionDto request)
        {
            _validator.ValidateAndThrow(request);
            var modelVersion = Context.ModelVersions.Find(request.Id);

            if (modelVersion == null)
            {
                throw new EntityNotFoundException(nameof(Domain.ModelVersion), request.Id );
            }

            modelVersion.StockQuantity = request.StockQuantity;
            Context.SaveChanges();

            
        }
    }
}
