using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Configuration;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Configuration
{
    public class EfGetConfigurationsQuery : EfUseCase, IGetConfigurationsQuery
    {
        public EfGetConfigurationsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 61;

        public string Name => "Get Configurations";

        public string Description => "Get Configurations";

        public IEnumerable<ConfigurationDto> Execute(BaseSearch search)
        {
            var conf=Context.Configurations.Select(x => new ConfigurationDto
            {
                Id = x.Id,
                UserId = x.UserId,
                CreatedAt = x.CreatedAt,
                Components = x.Components.Select(x => new ComponentDto
                {
                    Id = x.ModelVersionId,
                    ModelVersionName = x.ModelVersion.Model.Brand.Name+ " "+ x.ModelVersion.Model.Name,
                    Price = x.ModelVersion.Prices.Where(x=>x.DateFrom<DateTime.Now && x.DateTo>DateTime.Now).FirstOrDefault().PriceValue,
                    Quantity = x.Quantity
                }),

            });
            return conf;

        }
    }
}
