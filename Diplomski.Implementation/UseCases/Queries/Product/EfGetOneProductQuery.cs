using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Products;
using Diplomski.DataAccess;
using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Product
{
    public class EfGetOneProductQuery : EfUseCase, IGetOneProductQuery
    {
        public EfGetOneProductQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 60 ;

        public string Name => "Single product";

        public string Description => "Single product";

        public ProductDto Execute(int search)
        {
            var product = Context.ModelVersions.Where(x => x.Id == search).Select(x => new ProductDto
            {
                Id = x.Id,
                BrandName = x.Model.Brand.Name,
                ModelName = x.Model.Name,
                Price = x.Prices.Where(x => x.DateFrom <= DateTime.Now && x.DateTo >= DateTime.Now).FirstOrDefault().PriceValue,
                Specifications = x.ModelVersionSpecifications.Select(x => new SpecificationDto
                {
                    Id = x.Specification.Id,
                    Name = x.Specification.Name,
                    ParentId = x.Specification.ParentId,
                    ParentName = x.Specification.Parent.Name
                }),
                Pictures = x.Pictures.Select(x => new PictureDto
                {
                    Id = x.Id,
                    Path = x.Path,
                    ModelVersionId = x.ModelVersionId,
                    ModelVersionName = x.ModelVersion.Model.Brand.Name + " " + x.ModelVersion.Model.Name

                }),


            }).FirstOrDefault();

            if (product == null)
            {
                throw new EntityNotFoundException("Product", search);
            }

            return product;

        }
    }
}
