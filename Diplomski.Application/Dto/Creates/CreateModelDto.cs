using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Creates
{
    public class CreateModelDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
