using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Role
{
    public class EfGetRolesQuery : EfUseCase, IGetRolesQuery
    {
        public EfGetRolesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Search Roles";

        public string Description => "Search Roles";

        public IEnumerable<RoleDto> Execute(BaseSearch search)
        {
            var query = Context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            });

            


            
        }
    }
}
