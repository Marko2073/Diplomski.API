using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Model
{
    public class EfGetModelsQuery : EfUseCase, IGetModelsQuery
    {
        public EfGetModelsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Search Models";

        public string Description => "Search Models";

        public IEnumerable<ModelDto> Execute(BaseSearch search)
        {
            var query = Context.Models.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ModelDto
            {
                Id = x.Id,
                Name = x.Name,
                BrandName = x.Brand.Name,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name

            }).ToList();


        }
    }
}
