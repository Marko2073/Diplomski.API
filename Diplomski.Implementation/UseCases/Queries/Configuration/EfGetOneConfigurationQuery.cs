using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Configuration;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Configuration
{
    public class EfGetOneConfigurationQuery : EfUseCase, IGetOneConfigurationQuery
    {
        public EfGetOneConfigurationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 62;

        public string Name => "Single Configuration";

        public string Description => "Single Configuration";

        public ConfigurationDto Execute(int search)
        {
            var conf = Context.Configurations.Where(x => x.Id == search).Select(x => new ConfigurationDto
            {
                Id = x.Id,
                UserId = x.UserId,
                CreatedAt = x.CreatedAt,
                Components = x.Components.Select(x => new ComponentDto
                {
                    Id = x.ModelVersionId,
                    ModelVersionName = x.ModelVersion.Model.Brand.Name + " " + x.ModelVersion.Model.Name,
                    Price = x.ModelVersion.Prices.Where(x => x.DateFrom < DateTime.Now && x.DateTo > DateTime.Now).FirstOrDefault().PriceValue,
                    Quantity = x.Quantity
                }),

            }).FirstOrDefault();

            if (conf == null)
            {
                throw new EntityNotFoundException("Configuration", search);
            }

            return conf;
            
        }
    }
}
