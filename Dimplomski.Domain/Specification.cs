using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Specification:Entity
    {

        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Specification Parent { get; set; }
        public virtual ICollection<Specification> Childrens { get; set; } = new HashSet<Specification>();
        public virtual ICollection<ModelVersionSpecification> ModelVersionSpecifications { get; set; } = new HashSet<ModelVersionSpecification>();
        public virtual ICollection<CategorySpecification> CategorySpecifications { get; set; } = new HashSet<CategorySpecification>();

    }
}
