﻿using Diplomski.Application.Dto.Gets;
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

        public int Id => 206;

        public string Name => "Search All Products";

        public string Description => "Search All Products";

        public IEnumerable<ProductDto> Execute(BaseSearch search)
        {
            var query = Context.ModelVersions.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Model.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ProductDto
            {
                Id = x.Id,
                BrandName = x.Model.Brand.Name,
                ModelName = x.Model.Name,
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
