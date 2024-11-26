using Diplomski.Application.Dto.Creates;
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
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private CreateBrandDtoValidator _validator;
        public EfCreateBrandCommand(DatabaseContext context, CreateBrandDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Create Brand";

        public string Description => "Create Brand";

        public void Execute(CreateBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Brands.Add(new Domain.Brand
            {
                Name = request.Name
            });

            Context.SaveChanges();

        }
    }
}
