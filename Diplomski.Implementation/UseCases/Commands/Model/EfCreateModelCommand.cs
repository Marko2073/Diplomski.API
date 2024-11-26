using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Model
{
    public class EfCreateModelCommand : EfUseCase, ICreateModelCommand
    {
        public CreateModelDtoValidator _validator;
        public EfCreateModelCommand(DatabaseContext context, CreateModelDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Model";

        public string Description => "Create Model";

        public void Execute(CreateModelDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Models.Add(new Domain.Model
            {
                Name = request.Name,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId
            });

            Context.SaveChanges();

            
        }
    }
}
