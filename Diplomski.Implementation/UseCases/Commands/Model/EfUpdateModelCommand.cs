using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
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
    public class EfUpdateModelCommand : EfUseCase, IUpdateModelCommand
    {
        public UpdateModelDtoValidator _validator;
        public EfUpdateModelCommand(DatabaseContext context, UpdateModelDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Update Model";

        public string Description => "Update Model";

        public void Execute(UpdateModelDto request)
        {
            _validator.ValidateAndThrow(request);

            var model = Context.Models.Find(request.Id);
            if (model == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Model), request.Id.Value);
            }

            model.Name = request.Name;
            model.BrandId = request.BrandId;
            model.CategoryId = request.CategoryId;
            model.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();

            
            
        }
    }
}
