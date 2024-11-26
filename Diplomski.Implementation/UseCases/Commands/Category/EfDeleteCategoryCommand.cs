using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Category
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Delete Category";

        public string Description => "Delete Category";

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Category), request);
            }

            if (Context.Models.Any(x => x.CategoryId == request))
            {
                throw new ConflictException("Category has models connected to it.");
            }

            

            Context.Categories.Remove(category);

            Context.SaveChanges();
        }
    }
}
