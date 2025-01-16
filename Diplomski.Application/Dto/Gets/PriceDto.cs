using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class PriceDto
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Value { get; set; }
        public int ModelVersionId { get; set; }
        public string ModelVersionName { get; set; }
    }
}
