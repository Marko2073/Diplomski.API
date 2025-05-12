using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Products;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Product
{
    public class EfGetProductsQuery : EfUseCase, IGetProductsQuery
    {
        public EfGetProductsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 59;

        public string Name => "Search All Products";

        public string Description => "Search All Products";

        public IEnumerable<ProductDto> Execute(ProductSearch search)
        {
            var query = Context.ModelVersions.AsQueryable();

            if(search.CategoryId != 0)
            {
                query = query.Where(x => x.Model.CategoryId == search.CategoryId);
            }
            if(!string.IsNullOrEmpty(search.CategoryName))
            {
                query = query.Where(x => x.Model.Category.Name.ToLower().Contains(search.CategoryName.ToLower()));
            }
            if(search.BrandId != null)
            {
                query = query.Where(x => search.BrandId.Contains(x.Model.BrandId));

                
            }
            if(search.ModelVersionId != null)
            {
                query = query.Where(x => x.Id == search.ModelVersionId);
            }
            if(search.ModelId != null)
            {
                query = query.Where(x => x.ModelId == search.ModelId);
            }
            if (search.SpecificationIds != null && search.SpecificationIds.Any())
            {
                var specifications = Context.Specifications
                    .Where(s => search.SpecificationIds.Contains(s.Id))
                    .Select(s => new { s.Id, s.ParentId })
                    .ToList();

                var groupedSpecIds = specifications
                    .GroupBy(s => s.ParentId)
                    .ToList();

                foreach (var group in groupedSpecIds)
                {
                    var specIds = group.Select(g => g.Id).ToList();
                    query = query.Where(modelVersion => modelVersion.ModelVersionSpecifications.Any(spec => specIds.Contains(spec.SpecificationId)));
                }
            }


            return query.Select(x => new ProductDto
            {
                Id = x.Id,
                BrandName = x.Model.Brand.Name,
                ModelName = x.Model.Name,
                categoryName = x.Model.Category.Name,
                Price = x.Prices.Where(x=>x.DateFrom <= DateTime.Now && x.DateTo >= DateTime.Now).FirstOrDefault().PriceValue,
                Specifications = x.ModelVersionSpecifications.Select(x=> new SpecificationDto
                {
                    Id = x.Specification.Id,
                    Name = x.Specification.Name,
                    ParentId = x.Specification.ParentId,
                    ParentName = x.Specification.Parent.Name
                }),
                Pictures = x.Pictures.Select(x=> new PictureDto
                {
                    Id = x.Id,
                    Path = x.Path,
                    ModelVersionId = x.ModelVersionId,
                    ModelVersionName = x.ModelVersion.Model.Brand.Name + " " + x.ModelVersion.Model.Name
                    
                }),
                

            });
            
        }
    }
}
