using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.User;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.User
{
    public class EfGetOneUserQuery : EfUseCase, IGetOneUserQuery
    {
        public EfGetOneUserQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Get One User";

        public string Description => "Get One User";

        public UserDto Execute(int search)
        {
            
            var user = Context.Users
                               .Where(x => x.Id == search)
                               .Select(x => new UserDto
                               {
                                   Id = x.Id,
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   Email = x.Email,
                                   Path = x.Path,
                                   Phone = x.Phone,
                                   Address = x.Address,
                                   City = x.City,

                               }).FirstOrDefault();
                               
            if (user == null)
            {
                throw new EntityNotFoundException(nameof(Domain.User), search);
            }
            return user;

        }
    }
}
