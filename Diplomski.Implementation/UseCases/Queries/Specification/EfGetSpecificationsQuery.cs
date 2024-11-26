using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Specification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Specification
{
    public class EfGetSpecificationsQuery : EfUseCase, IGetSpecificationsQuery
    {
        public EfGetSpecificationsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Search Specifications";

        public string Description => "Search Specifications";

        public IEnumerable<SpecificationDto> Execute(BaseSearch search)
        {
            var query = Context.Specifications.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new SpecificationDto
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = (int)x.ParentId,
                ParentName = x.Parent != null ? x.Parent.Name : null

            }).ToList();

            
        }
    }
}
