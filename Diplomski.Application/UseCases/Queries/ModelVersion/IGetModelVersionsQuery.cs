using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.ModelVersion
{
    public interface IGetModelVersionsQuery : IQuery<BaseSearch, IEnumerable<ModelVersionDto>>
    {
    }
}
