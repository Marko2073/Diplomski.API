using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Role
{
    public class EfDeleteRoleCommand : EfUseCase, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Delete Role";

        public string Description => "Delete Role";

        public void Execute(int request)
        {
            var role = Context.Roles.Include(x => x.Users).FirstOrDefault(x => x.Id == request);
            if (role == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Role), request);
            }
            if(role.Users.Count > 0)
            {
                throw new ConflictException("Role has users and cannot be deleted");
            }

            Context.Roles.Remove(role);


                
            Context.SaveChanges();
            
        }
    }
}
