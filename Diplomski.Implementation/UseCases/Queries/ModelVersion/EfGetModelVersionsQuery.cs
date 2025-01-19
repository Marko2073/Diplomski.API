using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.ModelVersion;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.ModelVersion
{
    public class EfGetModelVersionsQuery : EfUseCase, IGetModelVersionsQuery
    {
        public EfGetModelVersionsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Search Model Versions";

        public string Description => "Search Model Versions";

        public IEnumerable<ModelVersionDto> Execute(BaseSearch search)
        {

            var query = Context.ModelVersions.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Model.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ModelVersionDto
            {
                Id = x.Id,
                ModelId = x.ModelId,
                StockQuantity = x.StockQuantity,
                BrandName = x.Model.Brand.Name,
                ModelName = x.Model.Name,
                Name = x.Model.Brand.Name + " " + x.Model.Name + " " + x.Id
                
            });
            
        }
    }
}
