using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.Column
{
    public interface IGetColumnsQuery : IQuery<string, IEnumerable<string>>
    {
    }
}
