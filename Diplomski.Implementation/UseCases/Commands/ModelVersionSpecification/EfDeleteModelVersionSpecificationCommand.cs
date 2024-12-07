using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.ModelVersionSpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.ModelVersionSpecification
{
    public class EfDeleteModelVersionSpecificationCommand : EfUseCase, IDeleteModelVersionSpecificationCommand
    {
        public EfDeleteModelVersionSpecificationCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 50;

        public string Name => "Delete ModelVersionSpecification";

        public string Description => "Delete ModelVersionSpecification";

        public void Execute(int request)
        {
            var mvs = Context.ModelVersionSpecifications.Find(request);

            if (mvs == null)
            {
                throw new EntityNotFoundException(nameof(Domain.ModelVersion), request);
            }

            Context.ModelVersionSpecifications.Remove(mvs);

            Context.SaveChanges();

        }
    }
}
