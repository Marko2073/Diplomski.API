using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Model
{
    public class EfGetOneModelQuery : EfUseCase, IGetOneModelQuery
    {
        public EfGetOneModelQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Single Model";

        public string Description => "Single Model";

        public ModelDto Execute(int search)
        {
            var model = Context.Models
                .Where(x => x.Id == search)
                .Select(x => new ModelDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandName = x.Brand.Name,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name

                    

                })
                .FirstOrDefault();

            if (model == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Model), search);
            }

            return model;

        }
    }
}
