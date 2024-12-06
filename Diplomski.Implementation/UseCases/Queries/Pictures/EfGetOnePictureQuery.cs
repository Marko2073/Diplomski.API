using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Pictures;
using Diplomski.DataAccess;
using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Pictures
{
    public class EfGetOnePictureQuery : EfUseCase, IGetOnePictureQuery
    {
        public EfGetOnePictureQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Single Picture";

        public string Description => "Single Picture";

        public PictureDto Execute(int search)
        {
            var picture = Context.Pictures.Where(x => x.Id == search).Select(x => new PictureDto
            {
                Id = x.Id,
                Path = x.Path,
                ModelVersionId = x.ModelVersionId
            }).FirstOrDefault();

            if (picture == null)
            {
                throw new EntityNotFoundException(nameof(Picture), search);
            }

            return picture;

        }
    }
}
