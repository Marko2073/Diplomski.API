using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class ModelVersion:Entity
    {
        public int ModelId { get; set; }
        public int StockQuantity { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<ModelVersionSpecification> ModelVersionSpecifications { get; set; } = new HashSet<ModelVersionSpecification>();
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>();
        public virtual ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public virtual ICollection<Component> Components { get; set; } = new HashSet<Component>();





    }
}
