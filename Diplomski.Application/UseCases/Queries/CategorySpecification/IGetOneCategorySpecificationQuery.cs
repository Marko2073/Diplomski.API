using Diplomski.Application.Dto.Gets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.CategorySpecification
{
    public interface IGetOneCategorySpecificationQuery : IQuery<int, CategorySpecificationDto>
    {
    }
}
