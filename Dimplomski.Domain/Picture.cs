﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Domain
{
    public class Picture:Entity
    {
        public string Path { get; set; }
        public int ModelVersionId { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }
    }
}
