using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Model
{
    public class EfDeleteModelCommand : EfUseCase, IDeleteModelCommand
    {
        public EfDeleteModelCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Delete Model";

        public string Description => "Delete Model";

        public void Execute(int request)
        {
            var model = Context.Models.Find(request);
            if (model == null)
            {

                throw new EntityNotFoundException(nameof(Domain.Model), request);
            }

            if (Context.ModelVersions.Any(x => x.ModelId == request))
            {
                throw new ConflictException("Model has versions connected to it.");
            }

            Context.Models.Remove(model);

            Context.SaveChanges();
        }
    }
}
