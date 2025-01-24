using Diplomski.Application.Dto.Creates;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class CreatePriceDtoValidator : AbstractValidator<CreatePriceDto>
    {
        public CreatePriceDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.ModelVersionId)
                .NotEmpty()
                .Must(x => context.ModelVersions.Any(mv => mv.Id == x))
                .WithMessage("Model version with an id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.Value)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.DateTo)
                .NotEmpty()
                .GreaterThan(x => x.DateFrom);


            RuleFor(x => x)
                .Must(x => !context.Prices.Any(p => p.ModelVersionId == x.ModelVersionId && x.DateFrom >= p.DateFrom && x.DateFrom <= p.DateTo || x.DateTo >= p.DateFrom && x.DateTo <= p.DateTo))
                .WithMessage("Price for this model version already exists in this period.");
           
        }
    }
}
