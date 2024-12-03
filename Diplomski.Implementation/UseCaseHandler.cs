using Diplomski.Application;
using Diplomski.Application.Logging;
using Diplomski.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diplomski.Implementation
{
    public class UseCaseHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;
        private readonly IExceptionLogger _exception;

        public UseCaseHandler(IApplicationActor actor, IUseCaseLogger logger, IExceptionLogger exception)
        {
            _logger = logger;
            _actor = actor;
            _exception = exception;

        }


        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleCrossCuttingConcerns(command, data);
                var stopWatch =  new Stopwatch();
                stopWatch.Start();
                command.Execute(data);
                stopWatch.Stop();

                Console.WriteLine(command.Name+ $" Execution time: {stopWatch.ElapsedMilliseconds} ms");


            }
            catch(Exception e)
            {
                _exception.Log(e);
                throw;
            }
            
        }
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {

                HandleCrossCuttingConcerns(query, data);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var response=query.Execute(data);
                stopWatch.Stop();

                Console.WriteLine(query.Name + $" Execution time: {stopWatch.ElapsedMilliseconds} ms");

                return response;
            }
            catch (Exception e)
            {
                _exception.Log(e);
                throw;
            }

        }
        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {

            
            //if (!HasPermissionForUseCase(useCase))
            //{
            //    throw new UnauthorizedAccessException($"User '{_actor.FirstName}' is not authorized to execute use case: {useCase.Name}");
            //}



            var log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = useCase.Name,
                Username = _actor.FirstName,
            };

            _logger.Log(log);
        }

        private bool HasPermissionForUseCase(IUseCase useCase)
        {
            if (_actor.RoleId == 2) 
            {
                return true; 
            }

            
            if (_actor.RoleId == 3)
            {
                
                var allowedUseCases = new List<int>
                {
                    1,2
                
                   
                };

                return allowedUseCases.Contains(useCase.Id);
            }

            return false;
        }
    }
}
