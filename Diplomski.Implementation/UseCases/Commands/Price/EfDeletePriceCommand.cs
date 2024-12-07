using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Price;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Price
{
    public class EfDeletePriceCommand : EfUseCase, IDeletePriceCommand
    {
        public EfDeletePriceCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 55;

        public string Name => "Delete Price";

        public string Description => "Delete Price";

        public void Execute(int request)
        {
            var price = Context.Prices.Find(request);

            if (price == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Price), request);
            }

            if (price.DateTo < DateTime.Now)
            {
                throw new ConflictException("Cannot delete a price whose validity period has already passed.");
            }
            var isPriceActiveNow = price.DateFrom <= DateTime.Now && price.DateTo >= DateTime.Now;


            if (isPriceActiveNow)
            {
                throw new ConflictException("Price is active now, you can only update this price");
            }

            

            Context.Prices.Remove(price);

            Context.SaveChanges();
            
        }
    }
}
