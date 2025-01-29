using Diplomski.Application.Dto.Updates;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class UpdatePriceDtoValidator :AbstractValidator<UpdatePriceDto>
    {
        public UpdatePriceDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.Value).NotEmpty().WithMessage("Price value is required.");
            RuleFor(x => x.DateFrom).NotEmpty().WithMessage("Date from is required.");
            RuleFor(x => x.DateTo).NotEmpty().WithMessage("Date to is required.");
            RuleFor(x => x.ModelVersionId)
                .NotEmpty()
                .Must(x => context.ModelVersions.Any(mv => mv.Id == x))
                .WithMessage("Model version with an id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.Value)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Price value must be greater than 0.");


            RuleFor(x => x.DateTo)
                .NotEmpty()
                .GreaterThan(x => x.DateFrom)
                .WithMessage("Date to must be greater than date from.");


        }
    }
}
