using Diplomski.Application.Dto.Updates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class UpdateModelVersionDtoValidator : AbstractValidator<UpdateModelVersionDto>
    {
        public UpdateModelVersionDtoValidator()
        {
            RuleFor(x => x.StockQuantity).NotEmpty().WithMessage("Model must have quantity");
            RuleFor(x => x.StockQuantity).GreaterThan(-1).WithMessage("Quantity must be greater than 0");
        }
    }
}
