using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Brand
{
    public class EfDeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Delete Brand";

        public string Description => "Delete Brand";

        public void Execute(int request)
        {
            var brand = Context.Brands.Include(x => x.Models).FirstOrDefault(x => x.Id == request);

            if (brand == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Brand).ToString(), request);
            }

            if (brand.Models.Count > 0)
            {
                throw new ConflictException("Brand has models and cannot be deleted");
            }

            Context.Brands.Remove(brand);
            Context.SaveChanges();

        }
    }
}
