using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ModelVersionId { get; set; }
        public string ModelVersionName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
