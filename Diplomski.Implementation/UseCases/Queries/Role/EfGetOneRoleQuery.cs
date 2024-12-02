using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Role
{
    public class EfGetOneRoleQuery : EfUseCase, IGetOneRoleQuery
    {
        public EfGetOneRoleQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Single Role";

        public string Description => "Single Role";

        public RoleDto Execute(int search)
        {
            var role = Context.Roles.Find(search);

            if (role == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Role), search);
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
            
        }
    }
}
