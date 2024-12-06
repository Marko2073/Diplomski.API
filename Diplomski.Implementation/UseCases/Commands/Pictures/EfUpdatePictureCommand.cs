using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Pictures;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Pictures
{
    public class EfUpdatePictureCommand : EfUseCase, IUpdatePictureCommand
    {

        public EfUpdatePictureCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "Update Picture";

        public string Description => "Update Picture";

        public void Execute(UpdatePictureDto request)
        {

            var picture = Context.Pictures.Find(request.Id);
            if (picture == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Picture), request.Id.Value);
            }

            if (request.PicturePath != null)
            {
                var extension = Path.GetExtension(request.PicturePath.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    request.PicturePath.CopyTo(fs);
                }

                picture.Path = filename;

                Context.SaveChanges();
            }

        }
    }
}
