using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(DatabaseContext context) 
        {
            Context = context;
        }
        protected DatabaseContext Context {  get; }
            
    }
}
