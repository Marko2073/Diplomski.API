using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.CategorySpecification
{
    public class EfGetCategorySpecificationsQuery : EfUseCase, IGetCategorySpecificationsQuery
    {
        public EfGetCategorySpecificationsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Search CategorySpecifications";

        public string Description => "Search CategorySpecifications";

        public IEnumerable<CategorySpecificationDto> Execute(BaseSearch search)
        {
            var query = Context.CategorySpecifications.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Category.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Specification.Name.ToLower().Contains(search.Keyword.ToLower()));
            }


            return query.Select(x => new CategorySpecificationDto
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                SpecificationId = x.SpecificationId,
                SpecificationName = x.Specification.Name
            }).ToList();


            
        }
    }
}
