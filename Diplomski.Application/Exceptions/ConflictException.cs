using System;
using System.Collections.Generic;
using System.Text;

namespace Diplomski.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string reason) : base(reason)
        {
            
        }
    }
}
