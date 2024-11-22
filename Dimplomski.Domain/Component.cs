using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Component : Entity
    {
        public int Quantity { get; set; }
        public int ModelVersionId { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }
        public int ConfigurationId { get; set; }
        public virtual Configuration Configuration{ get; set; }
    }
}
