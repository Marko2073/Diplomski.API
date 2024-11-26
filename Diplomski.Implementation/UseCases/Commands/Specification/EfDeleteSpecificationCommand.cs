using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Specification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Specification
{
    public class EfDeleteSpecificationCommand : EfUseCase, IDeleteSpecificationCommand
    {
        public EfDeleteSpecificationCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Delete Specification";

        public string Description => "Delete Specification";

        public void Execute(int request)
        {
            var specification = Context.Specifications.Find(request);

            if (specification == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Specification), request);
            }
            if(Context.ModelVersionSpecifications.Any(x => x.SpecificationId == request) || Context.Specifications.Any(x => x.ParentId == request))
            {
                throw new ConflictException("This specification is in use and cannot be deleted");
            }

            Context.Specifications.Remove(specification);

            Context.SaveChanges();
           
        }
    }
}
