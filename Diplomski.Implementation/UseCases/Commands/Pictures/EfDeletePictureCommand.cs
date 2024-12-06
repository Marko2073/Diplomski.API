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
    public class EfDeletePictureCommand : EfUseCase, IDeletePictureCommand
    {
        public EfDeletePictureCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 40;

        public string Name => "Delete Picture";

        public string Description => "Delete Picture";

        public void Execute(int request)
        {
            var picture = Context.Pictures.Find(request);
            if (picture == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Picture), request);
            }

            Context.Pictures.Remove(picture);
            Context.SaveChanges();
            
        }
    }
}
