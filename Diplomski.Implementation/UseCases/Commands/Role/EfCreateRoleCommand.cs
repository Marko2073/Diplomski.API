using Diplomski.Application.Dto.Creates;
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
    public class EfCreateRoleCommand : EfUseCase, ICreateRoleCommand
    {
        public CreateRoleDtoValidator _validator;

        public EfCreateRoleCommand(DatabaseContext context, CreateRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Create Role";

        public string Description => "Create Role";

        public void Execute(CreateRoleDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Roles.Add(new Domain.Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
            
        }
    }
}
