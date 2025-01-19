using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class ModelVersionSpecificationDto : BaseDto
    {
        public int ModelVersionId { get; set; }
        public string ModelVersionName { get; set; }
        public int SpecificationId { get; set; }
        public string SpecificationParent { get; set; }
        public string SpecificationValue { get; set; }
        public int ParentId { get; set; }

    }
}
