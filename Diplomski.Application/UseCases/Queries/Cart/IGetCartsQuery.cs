using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.Cart
{
    public interface IGetCartsQuery: IQuery<BaseSearch, IEnumerable<CartDto>>
    {
    }
}
