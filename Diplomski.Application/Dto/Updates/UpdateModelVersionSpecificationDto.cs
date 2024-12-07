using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Updates
{
    public class UpdateModelVersionSpecificationDto
    {
        public int? Id { get; set; }
        public int ModelVersionId { get; set; }
        public int SpecificationId { get; set; }
    }
}
