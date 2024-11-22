using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Configuration : Entity
    {
        public virtual ICollection<Component> Components{ get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public bool isProcessed { get; set; }
        public bool isSaved { get; set; }
    }
}
