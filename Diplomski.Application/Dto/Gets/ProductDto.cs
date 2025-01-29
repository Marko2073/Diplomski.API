using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal? Price { get; set; }
        public IEnumerable<SpecificationDto> Specifications { get; set; }
        public IEnumerable<PictureDto> Pictures{ get; set; }
    }
}
