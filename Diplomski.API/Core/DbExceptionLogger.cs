using Diplomski.Application;
using Diplomski.DataAccess;
using Diplomski.Domain;

namespace Diplomski.API.Core
{
    public class DbExceptionLogger : IExLogger
    {
        private readonly DatabaseContext _context;

        public DbExceptionLogger(DatabaseContext context)
        {
            _context = context;
            
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            var log = new ErrorLog
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow,
            };

            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
