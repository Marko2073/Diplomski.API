using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Childrens { get; set; } = new HashSet<Category>();
        public virtual ICollection<Model> Models { get; set; } = new HashSet<Model>();
        public virtual ICollection<CategorySpecification> CategorySpecifications { get; set; } = new HashSet<CategorySpecification>();
    }
}
