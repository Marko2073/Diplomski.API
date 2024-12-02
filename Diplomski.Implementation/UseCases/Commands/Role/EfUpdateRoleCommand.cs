using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.DataAccess;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Role
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        public UpdateRoleDtoValidator _validator;
        public EfUpdateRoleCommand(DatabaseContext context, UpdateRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Update Role";

        public string Description => "Update Role";

        public void Execute(UpdateRoleDto request)
        {
            _validator.ValidateAndThrow(request);
            var role = Context.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Role), request.Id);
            }

            role.Name = request.Name;
            role.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
            
        }
    }
}
