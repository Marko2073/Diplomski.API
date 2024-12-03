using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.User;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.User
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Search Users";

        public string Description => "Search Users";

        public IEnumerable<UserDto> Execute(BaseSearch search)
        {
            var users = Context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                users = users.Where(x => x.FirstName.ToLower().Contains(search.Keyword.ToLower()) || x.LastName.ToLower().Contains(search.Keyword.ToLower()));
            }

            return users.Select(x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Path = x.Path,
                Phone = x.Phone,
                Address = x.Address,
                City = x.City,

            }).ToList();
        }
    }
}
