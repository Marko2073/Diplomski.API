using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Specification;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Specification
{
    public class EfGetOneSpecificationQuery : EfUseCase, IGetOneSpecificationQuery
    {
        public EfGetOneSpecificationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Single Specification";

        public string Description => "Single Specification";

        public SpecificationDto Execute(int search)
        {
            var spec = Context.Specifications
                                .Where(x => x.Id == search)
                                .Select(x => new SpecificationDto
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    ParentId = (int)x.ParentId,
                                    ParentName = x.Parent != null ? x.Parent.Name : null

                                }).FirstOrDefault();
            if(spec == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Specification), search);
            }
            return spec;

            
            
        }
    }
}
