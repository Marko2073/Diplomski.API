using Diplomski.Implementation.Validators;
using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.ModelVersion
{
    public class EfCreateModelVersionCommand : EfUseCase, ICreateModelVersionCommand
    {
        public CreateModelVersionDtoValidator _validator;
        public EfCreateModelVersionCommand(DatabaseContext context, CreateModelVersionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Create Model Version";

        public string Description => "Create Model Version";

        public void Execute(CreateModelVersionDto request)
        {
            _validator.ValidateAndThrow(request);
            Context.ModelVersions.Add(new Domain.ModelVersion
            {
                ModelId = request.ModelId,
                StockQuantity = request.StockQuantity
            });

            Context.SaveChanges();
            
        }
    }
}
