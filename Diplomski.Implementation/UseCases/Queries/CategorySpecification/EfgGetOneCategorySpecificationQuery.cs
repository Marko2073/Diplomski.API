using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.CategorySpecification
{
    public class EfGetOneCategorySpecificationQuery : EfUseCase, IGetOneCategorySpecificationQuery
    {
        public EfGetOneCategorySpecificationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Single CategorySpecification";

        public string Description => "Single CategorySpecification";

        public CategorySpecificationDto Execute(int search)
        {
            var catspec = Context.CategorySpecifications
                .Where(x => x.Id == search)
                .Select(x => new CategorySpecificationDto
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    SpecificationId = x.SpecificationId,
                    SpecificationName = x.Specification.Name
                }).FirstOrDefault();

            if (catspec == null)
            {
                throw new EntityNotFoundException(nameof(Domain.CategorySpecification), search);
            }

            return catspec;

        }
    }
}
