using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class SpecificationDto : BaseDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }

    }
}
