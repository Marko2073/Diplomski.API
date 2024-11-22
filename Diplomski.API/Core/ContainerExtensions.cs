
using AspProjekat2024.Implementation.Logging;
using Diplomski.API.Core;
using Diplomski.Application;
using Diplomski.Application.Logging;
using Diplomski.Application.UseCases.Commands;
using Diplomski.Application.UseCases.Queries;
using Diplomski.Implementation;
using Diplomski.Implementation.Logging;
using Diplomski.Implementation.UseCases.Commands;
using Diplomski.Implementation.UseCases.Queries;
using Diplomski.Implementation.UseCases.Queries.Ef;
using System.IdentityModel.Tokens.Jwt;

namespace AspProjekat2024.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<IExLogger, DbExceptionLogger>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IGetOneBrandQuery, EfGetOneBrandQuery>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();






            //services.AddTransient<IEmailService>(provider =>
            //    new EmailService("smtp.gmail.com", 587, "marko.markovic.33.21@ict.edu.rs", "huvumdbwlqayjfzm"));
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            
            var token = request.Headers.Authorization.ToString().Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = handler.ReadJwtToken(token);
                var tokenIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "jti");
                return tokenIdClaim != null ? Guid.Parse(tokenIdClaim.Value) : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
