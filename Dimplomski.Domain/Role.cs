﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Role:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
