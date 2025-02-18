using Diplomski.Application.Dto.Gets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Creates
{
    public class CreateConfigurationDto 
    {
        public IEnumerable<CreateComponentDto> Components{ get; set; }
    }
}
