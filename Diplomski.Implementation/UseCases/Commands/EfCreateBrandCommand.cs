using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        public EfCreateBrandCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Create Brand";

        public string Description => "Create Brand";

        public void Execute(CreateBrandDto request)
        {
            Context.Brands.Add(new Domain.Brand
            {
                Name = request.Name
            });

            Context.SaveChanges();
            
        }
    }
}
