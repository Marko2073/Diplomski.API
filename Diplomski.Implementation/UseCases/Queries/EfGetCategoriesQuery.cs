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
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Search Categories";

        public string Description => "Search Categories";

        public IEnumerable<CategoryDto> Execute(BaseSearch search)
        {
            var query = Context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                ParentName = x.Parent.Name

            }).ToList();


            
        }
    }
}
