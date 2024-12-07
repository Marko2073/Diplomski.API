using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.ModelVersionSpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.ModelVersionSpecification
{
    public class EfGetOneModelVersionSpecificationQuery : EfUseCase, IGetOneModelVersionSpecificationQuery

    {
        public EfGetOneModelVersionSpecificationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 47;

        public string Name => "Single ModelVersionSpecification";

        public string Description => "Single ModelVersionSpecification";

        public ModelVersionSpecificationDto Execute(int search)
        {
            var mvs = Context.ModelVersionSpecifications.Where(x => x.Id == search).Select(x => new ModelVersionSpecificationDto
            {
                Id = x.Id,
                ModelVersionId = x.ModelVersionId,
                ModelVersionName = x.ModelVersion.Model.Name,
                SpecificationId = x.SpecificationId,
                SpecificationParent = x.Specification.Parent.Name,
                SpecificationValue = x.Specification.Name
            }).FirstOrDefault();

            if (mvs == null)
            {
                throw new EntityNotFoundException(nameof(ModelVersion), search);
            }

            return mvs;
        }
    }
}
