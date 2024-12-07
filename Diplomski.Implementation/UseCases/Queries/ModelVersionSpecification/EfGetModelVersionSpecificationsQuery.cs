using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.ModelVersionSpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.ModelVersionSpecification
{
    public class EfGetModelVersionSpecificationsQuery : EfUseCase, IGetModelVersionSpecificationsQuery
    {
        public EfGetModelVersionSpecificationsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Search ModelVersionSpecifications";

        public string Description => "Search ModelVersionSpecifications";

        public IEnumerable<ModelVersionSpecificationDto> Execute(BaseSearch search)
        {
            var query = Context.ModelVersionSpecifications.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.ModelVersion.Model.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ModelVersionSpecificationDto
            {
                Id = x.Id,
                ModelVersionId = x.ModelVersionId,
                ModelVersionName = x.ModelVersion.Model.Name,
                SpecificationId = x.SpecificationId,
                SpecificationParent = x.Specification.Parent.Name,
                SpecificationValue = x.Specification.Name
                
            });
            
        }
    }
}
