using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class CartItem : Entity
    {
        public int Quantity { get; set; }
        public int ModelVersionId { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
