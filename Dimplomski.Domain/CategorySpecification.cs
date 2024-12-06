using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class CategorySpecification : Entity
    {
        public int CategoryId { get; set; }
        public int SpecificationId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Specification Specification { get; set; }

    }
}
