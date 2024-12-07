using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
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
    public class EfUpdatePriceCommand : EfUseCase, IUpdatePriceCommand
    {
        public UpdatePriceDtoValidator _validator;
        public EfUpdatePriceCommand(DatabaseContext context, UpdatePriceDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 54;

        public string Name => "Update Price";

        public string Description => "Update Price";

        public void Execute(UpdatePriceDto request)
        {
            _validator.ValidateAndThrow(request);
            var price = Context.Prices.Find(request.Id);

            if (price == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Price), request.Id);
            }

            price.DateFrom = request.DateFrom;
            price.DateTo = request.DateTo;
            price.PriceValue = request.PriceValue;
            price.ModelVersionId = request.ModelVersionId;

            Context.SaveChanges();
        }
    }
}
