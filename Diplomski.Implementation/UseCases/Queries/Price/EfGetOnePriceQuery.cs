using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Price;
using Diplomski.DataAccess;
using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Price
{
    public class EfGetOnePriceQuery : EfUseCase, IGetOnePriceQuery
    {
        public EfGetOnePriceQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 52;

        public string Name => "Single Price";

        public string Description => "Single Price";

        public PriceDto Execute(int search)
        {
            var price = Context.Prices.Where(x => x.Id == search).Select(x => new PriceDto
            {
                Id = x.Id,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                Value = x.PriceValue,
                ModelVersionId = x.ModelVersionId
            }).FirstOrDefault();

            if (price == null)
            {
                throw new EntityNotFoundException(nameof(Price), search);
            }

            return price;

        }
    }
}
