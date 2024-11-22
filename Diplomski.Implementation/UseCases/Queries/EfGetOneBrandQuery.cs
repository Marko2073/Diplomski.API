using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries
{
    public class EfGetOneBrandQuery : EfUseCase, IGetOneBrandQuery
    {
        public EfGetOneBrandQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Single Brand";

        public string Description => "Single Brand ";

        public IEnumerable<BrandsDto> Execute(IdSearch search)
        {
            var query = Context.Brands.AsQueryable();
            query = query.Where(x => x.Id == search.Id);

            return query.Select(x => new BrandsDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            
        }
    }
}
