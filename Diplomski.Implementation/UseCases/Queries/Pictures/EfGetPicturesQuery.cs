using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Pictures;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Pictures
{
    public class EfGetPicturesQuery : EfUseCase, IGetPicturesQuery
    {
        public EfGetPicturesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Search Pictures";

        public string Description => "Search Pictures";

        public IEnumerable<PictureDto> Execute(BaseSearch search)
        {
            var query = Context.Pictures.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(p => p.Path.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(p => new PictureDto
            {
                Id = p.Id,
                Path = p.Path,
                ModelVersionId = p.ModelVersionId,
                ModelVersionName = p.ModelVersion.Model.Brand.Name + " " + p.ModelVersion.Model.Name
            });
            
        }
    }
}
