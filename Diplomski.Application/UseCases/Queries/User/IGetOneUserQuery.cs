﻿using Diplomski.Application.Dto.Gets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Queries.User
{
    public interface IGetOneUserQuery : IQuery<int, UserDto>
    {
    }
}
