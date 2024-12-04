using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.ModelVersion
{
    public class EfDeleteModelVersionCommand : EfUseCase, IDeleteModelVersionCommand
    {
        public EfDeleteModelVersionCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 35;

        public string Name => "Delete Model Version";

        public string Description => "Delete Model Version";

        public void Execute(int request)
        {
            var modelVersion = Context.ModelVersions.Find(request);

            if (modelVersion == null)
            {
                throw new EntityNotFoundException(nameof(Domain.ModelVersion), request);
            }

            var hasCartDependencies = Context.CartItems.Any(c => c.ModelVersionId == request);
            var hasPCComponentDependencies = Context.Components.Any(pc => pc.ModelVersionId == request);

            if (hasCartDependencies || hasPCComponentDependencies)
            {
                throw new ConflictException("ModelVersion has Carts od Configurations connected to it.");
            }


            Context.Pictures.RemoveRange(Context.Pictures.Where(p => p.ModelVersionId == request));
            Context.Prices.RemoveRange(Context.Prices.Where(p => p.ModelVersionId == request));
            Context.ModelVersionSpecifications.RemoveRange(Context.ModelVersionSpecifications.Where(mvs => mvs.ModelVersionId == request));



            Context.ModelVersions.Remove(modelVersion);

            
            Context.SaveChanges();

        }
    }
}
