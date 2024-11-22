using Diplomski.Application;

namespace Diplomski.API.Core
{
    public interface IExLogger
    {
        Guid Log(Exception ex, IApplicationActor actor );
    }
}
