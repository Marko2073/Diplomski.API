﻿using Diplomski.Application.Dto.Creates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Commands.Configuration
{
    public interface ICreateConfigurationCommand : ICommand<CreateConfigurationDto>
    {
    }
}
