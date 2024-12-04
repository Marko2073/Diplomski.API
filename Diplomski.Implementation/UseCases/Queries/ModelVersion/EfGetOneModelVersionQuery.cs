using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases;
using Diplomski.Application.UseCases.Queries.ModelVersion;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.ModelVersion
{
    public class EfGetOneModelVersionQuery : EfUseCase, IGetOneModelVersionQuery
    {
        public EfGetOneModelVersionQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Get One Model Version";

        public string Description => "Get One Model Version";

        public ModelVersionDto Execute(int search)
        {
            var modelVersion = Context.ModelVersions.Where(x => x.Id == search).Select(x => new ModelVersionDto
            {
                Id = x.Id,
                ModelId = x.ModelId,
                StockQuantity = x.StockQuantity
            }).FirstOrDefault();

            if (modelVersion == null)
            {
                throw new EntityNotFoundException(nameof(ModelVersion), search);
            }

            return modelVersion;
        }

    }
}
