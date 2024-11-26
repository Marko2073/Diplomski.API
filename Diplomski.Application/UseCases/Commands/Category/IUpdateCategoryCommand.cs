using Diplomski.Application.Dto.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.UseCases.Commands.Category
{
    public interface IUpdateCategoryCommand : ICommand<UpdateCategoryDto>
    {
    }
}
