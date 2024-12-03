using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.User
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Delete User";

        public string Description => "Delete User";

        public void Execute(int request)
        {
            var user = Context.Users.Include(x => x.Carts).FirstOrDefault(x => x.Id == request);

            //var user=Context.Users.Where(x=>x.Id==request).FirstOrDefault();


            if (user == null)
            {
                throw new EntityNotFoundException(nameof(Domain.User), request);
            }

            if (user.Carts.Any(x=>x.isProcessed==true))
            {
                throw new ConflictException("User has carts and cannot be deleted");
            }

            Context.Users.Remove(user);
            Context.SaveChanges();

        }
    }
}
