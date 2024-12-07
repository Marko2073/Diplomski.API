using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands.Price;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Price
{
    public class EfCreatePriceCommand : EfUseCase, ICreatePriceCommand
    {
        public CreatePriceDtoValidator _validator;
        public EfCreatePriceCommand(DatabaseContext context, CreatePriceDtoValidator validator) : base(context)
        {
            _validator = validator;

        }

        public int Id => 53;

        public string Name => "Create Price";

        public string Description => "Create Price";

        public void Execute(CreatePriceDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Prices.Add(new Domain.Price
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                PriceValue = request.PriceValue,
                ModelVersionId = request.ModelVersionId
            });

            Context.SaveChanges();
            
        }
    }
}
