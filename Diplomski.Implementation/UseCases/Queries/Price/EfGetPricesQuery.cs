using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Price;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Price
{
    public class EfGetPricesQuery : EfUseCase, IGetPricesQuery
    {
        public EfGetPricesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 51;

        public string Name => "Search Prices";

        public string Description => "Search Prices";

        public IEnumerable<PriceDto> Execute(PriceSearch search)
        {
            var query = Context.Prices.AsQueryable();

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.DateFrom >= search.DateFrom);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.DateTo <= search.DateTo);
            }

            if (search.MinValue.HasValue)
            {
                query = query.Where(x => x.PriceValue >= search.MinValue);
            }

            if (search.MaxValue.HasValue)
            {
                query = query.Where(x => x.PriceValue <= search.MaxValue);
            }


            return query.Select(x => new PriceDto
            {
                Id = x.Id,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                Value = x.PriceValue,
                ModelVersionId = x.ModelVersionId,
                ModelVersionName = x.ModelVersion.Model.Brand.Name + " " + x.ModelVersion.Model.Name
            });
            
        }
    }
}
