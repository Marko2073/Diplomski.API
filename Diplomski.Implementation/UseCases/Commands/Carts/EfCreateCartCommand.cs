using Diplomski.Application;
using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands;
using Diplomski.DataAccess;
using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Cart
{
    public class EfCreateCartCommand : EfUseCase, ICreateCartCommand
    {
        public IApplicationActor _actor;
        public EfCreateCartCommand(DatabaseContext context, IApplicationActor actor ) : base(context)
        {
            _actor = actor;
        }

        public int Id => 58;

        public string Name => "Create Cart";

        public string Description => "Create Cart";

        public void Execute(CreateCartDto request)

        {
            

                var user = Context.Users.Find(_actor.Id);
                if (user != null)
                {
                    var cart = new Domain.Cart
                    {
                        UserId = user.Id,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        isProcessed = true,
                        CartItems = new List<Domain.CartItem>()
                    };

                    Context.Carts.Add(cart);
                    Context.SaveChanges();
                    cart.CartItems = request.CartItems.Select(x => new Domain.CartItem
                    {
                        CartId = cart.Id,
                        ModelVersionId = x.ModelVersionId,
                        Quantity = x.Quantity
                    }).ToList();
                    Context.SaveChanges();

                }
                else
                {

                    throw new EntityNotFoundException(nameof(Domain.User), _actor.Id);
                }


            
            
        }
        
    }
}
