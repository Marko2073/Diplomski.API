using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Category;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Category
{
    public class EfGetOneCategoryQuery : EfUseCase, IGetOneCategoryQuery
    {
        public EfGetOneCategoryQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get One Category";

        public string Description => "Get One Category";

        public CategoryDto Execute(int search)
        {
            var category = Context.Categories
                .Where(x => x.Id == search)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    ParentName = x.Parent.Name

                })
                .FirstOrDefault();

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Category), search);
            }

            return category;
        }
    }
}
