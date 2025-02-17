using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.Configuration
{
    public interface IGetConfigurationsQuery : IQuery<BaseSearch, IEnumerable<ConfigurationDto>>
    {
    }
}
