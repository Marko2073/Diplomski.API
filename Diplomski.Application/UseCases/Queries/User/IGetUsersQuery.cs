using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.User
{
    public interface IGetUsersQuery : IQuery<BaseSearch, IEnumerable<UserDto>>
    {
    }
}
