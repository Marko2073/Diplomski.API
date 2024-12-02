using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Brand
{
    public class EfUpdateBrandCommand : EfUseCase, IUpdateBrandCommand
    {

        public UpdateBrandDtoValidator _validator;

        public EfUpdateBrandCommand(DatabaseContext context, UpdateBrandDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Update Brand";

        public string Description => "Update Brand";

        public void Execute(UpdateBrandDto request)
        {
            _validator.ValidateAndThrow(request);
            var brand = Context.Brands.Find(request.Id);
            if (brand == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Brand).ToString(), request.Id.Value);
            }

            brand.Name = request.Name;
            brand.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();

        }
    }
}
