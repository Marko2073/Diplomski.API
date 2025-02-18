using Diplomski.Application;
using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.Configuration;
using Diplomski.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.Configuration
{
    public class EfCreateConfigurationCommand : EfUseCase, ICreateConfigurationCommand
    {
        public IApplicationActor _actor;
        public EfCreateConfigurationCommand(DatabaseContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 63;

        public string Name => "Create Configuration";

        public string Description => "Create Configuration";

        public void Execute(CreateConfigurationDto request)
        {
            var user= _actor.Id;
            if(user == 0)
            {
                throw new EntityNotFoundException("User", user);
            }
            else
            {
                var configuration = new Domain.Configuration
                {
                    UserId = user,
                    isProcessed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Components = new List<Domain.Component>()
                };

                Context.Configurations.Add(configuration);
                Context.SaveChanges();
                configuration.Components = request.Components.Select(x => new Domain.Component
                {
                    ConfigurationId = configuration.Id,
                    ModelVersionId = x.ModelVersionId,
                    Quantity = x.Quantity
                }).ToList();
                Context.SaveChanges();


            }
           


            
        }
    }
}
