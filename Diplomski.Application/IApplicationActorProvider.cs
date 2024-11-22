using System;
using System.Collections.Generic;
using System.Text;

namespace Diplomski.Application
{
    public interface IApplicationActorProvider
    {
        IApplicationActor GetActor();
    }
}
