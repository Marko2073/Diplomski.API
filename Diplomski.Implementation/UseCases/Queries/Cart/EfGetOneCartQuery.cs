using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Queries.Cart;
using Diplomski.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Queries.Cart
{
    public class EfGetOneCartQuery : EfUseCase, IGetOneCartQuery
    {
        public EfGetOneCartQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 57;

        public string Name => "Single Cart";

        public string Description => "Single Cart";

        public CartDto Execute(int search)
        {
            var cart = Context.Carts
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.ModelVersion)
                        .ThenInclude(mv => mv.Prices) // Učitava i cene
                .Where(x => x.Id == search)
                .Select(x => new CartDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    CartItems = x.CartItems.Select(ci => new CartItemDto
                    {
                        Id = ci.Id,
                        ModelVersionId = ci.ModelVersionId,
                        ModelVersionName = ci.ModelVersion.Model.Brand.Name + " " + ci.ModelVersion.Model.Name,
                        Quantity = ci.Quantity,
                        Pictures = ci.ModelVersion.Pictures.Select(p => new PictureDto
                        {
                            Id = p.Id,
                            Path = p.Path
                        }),
                        Price = ci.ModelVersion.Prices
                            .Where(p => p.DateFrom < DateTime.Now && p.DateTo >= DateTime.Now)
                            .Select(p => (decimal?)p.PriceValue)
                            .FirstOrDefault() ?? 0
                    }).ToList()
                }).FirstOrDefault();

            if (cart == null)
            {
                throw new EntityNotFoundException(nameof(Domain.Brand), search);
            }

            // Računamo total price ručno
            decimal totalPrice = 0;
            foreach (var item in cart.CartItems)
            {
                decimal itemPrice = item.Price * item.Quantity;
                totalPrice += itemPrice;

                // Debug info
                Console.WriteLine($"CartItem ID: {item.Id}, Price: {item.Price}, Quantity: {item.Quantity}, Subtotal: {itemPrice}");
            }

            cart.TotalPrice = totalPrice;
            Console.WriteLine($"Cart ID: {cart.Id}, TotalPrice: {cart.TotalPrice}");

            return cart;
        }
    }
}
