using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Updates
{
    public class UpdateCategorySpecificationDto
    {
        public int? Id { get; set; }
        public int CategoryId { get; set; }
        public int SpecificationId { get; set; }
    }
}
