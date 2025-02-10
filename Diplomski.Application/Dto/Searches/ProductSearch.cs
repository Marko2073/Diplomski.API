using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Searches
{
    public class ProductSearch
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? BrandId { get; set; }
        public int? ModelVersionId { get; set; }
        public int? ModelId { get; set; }
        public List<int>? SpecificationIds { get; set; }
        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 2;
    }
}
