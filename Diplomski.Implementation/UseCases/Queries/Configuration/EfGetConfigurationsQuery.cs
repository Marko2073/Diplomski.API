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
            var conf = Context.Configurations
                .Select(x => new ConfigurationDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    CreatedAt = x.CreatedAt,

                    Components = x.Components.Select(c => new ComponentDto
                    {
                        Id = c.ModelVersionId,
                        ModelVersionName = c.ModelVersion.Model.Brand.Name + " " + c.ModelVersion.Model.Name,
                        // Ovde računamo važeću cenu iz ModelVersion.Prices
                        Price = c.ModelVersion.Prices
                            .Where(p => p.DateFrom < DateTime.Now && p.DateTo >= DateTime.Now)
                            .Select(p => (decimal?)p.PriceValue)
                            .FirstOrDefault() ?? 0,
                        Quantity = c.Quantity,
                        Pictures = c.ModelVersion.Pictures.Select(p => new PictureDto
                        {
                            Id = p.Id,
                            Path = p.Path
                        }).ToList()
                    }).ToList()
                })
                .ToList(); // Izvlačimo u memoriju

            foreach (var c in conf)
            {
                decimal totalPrice = 0;

                foreach (var item in c.Components)
                {
                    decimal itemPrice = item.Price * item.Quantity;
                    totalPrice += itemPrice;

                    // Debug info
                    Console.WriteLine($"Component ID: {item.Id}, Price: {item.Price}, Quantity: {item.Quantity}, Subtotal: {itemPrice}");
                }

                c.TotalPrice = totalPrice;
                Console.WriteLine($"Configuration ID: {c.Id}, TotalPrice: {c.TotalPrice}");
            }

            return conf;
        }
    }
}
