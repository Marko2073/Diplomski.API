using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Brand
{
    public class EfGetBrandsQuery : EfUseCase, IGetBrandsQuery
    {
        public EfGetBrandsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Search Brands";

        public string Description => "Search Brands using entity framework";

        public IEnumerable<BrandsDto> Execute(BaseSearch search)
        {

            var query = Context.Brands.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new BrandsDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

        }
    }
}
