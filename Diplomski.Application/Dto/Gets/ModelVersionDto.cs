using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class ModelVersionDto : BaseDto
    {
        public int ModelId { get; set; }
        public int StockQuantity { get; set; }
    }
}
