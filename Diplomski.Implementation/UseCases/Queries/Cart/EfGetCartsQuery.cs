﻿using Diplomski.Application.Dto.Gets;
using Diplomski.Application.Dto.Searches;
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
    public class EfGetCartsQuery : EfUseCase, IGetCartsQuery
    {
        public EfGetCartsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 56;

        public string Name =>"Get Carts";

        public string Description => "Get Carts";

        public IEnumerable<CartDto> Execute(BaseSearch search)
        {
            var carts = Context.Carts
                .Include(x => x.CartItems)
                    .ThenInclude(ci => ci.ModelVersion)
                        .ThenInclude(mv => mv.Prices) // Učitava i cene
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
                        Price = ci.ModelVersion.Prices
                            .Where(p => p.DateFrom < DateTime.Now && p.DateTo >= DateTime.Now)
                            .Select(p => (decimal?)p.PriceValue)
                            .FirstOrDefault() ?? 0
                    }).ToList()
                }).ToList(); // Izvlačimo podatke u memoriju

            // Sada iteriramo kroz svaki cart i računamo TotalPrice
            foreach (var cart in carts)
            {
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
            }

            return carts;
        }


    }
}
