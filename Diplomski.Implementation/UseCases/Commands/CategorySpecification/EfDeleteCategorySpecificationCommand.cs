using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.CategorySpecification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.CategorySpecification
{
    public class EfDeleteCategorySpecificationCommand : EfUseCase, IDeleteCategorySpecificationCommand
    {
        public EfDeleteCategorySpecificationCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 45;

        public string Name => "Delete CategorySpecification";

        public string Description => "Delete CategorySpecification";

        public void Execute(int request)
        {
            var catspec = Context.CategorySpecifications.Find(request);
            if (catspec == null)
            {
                throw new EntityNotFoundException(nameof(Domain.CategorySpecification), request);
            }

            Context.CategorySpecifications.Remove(catspec);
            Context.SaveChanges();
           
        }
    }
}
