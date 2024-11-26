using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Exceptions;
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

        public BrandsDto Execute(int search)
        {
            var brand = Context.Brands.Where(x => x.Id == search).Select(x=>new BrandsDto
            {
                Id= x.Id,
                Name = x.Name
            }).FirstOrDefault();

            if(brand==null)
            {
                throw new EntityNotFoundException(nameof(Domain.Brand), search);
            }
            return brand;
            
        }
    }
}
