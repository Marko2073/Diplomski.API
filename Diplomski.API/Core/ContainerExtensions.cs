
using AspProjekat2024.Implementation.Logging;
using Diplomski.API.Core;
using Diplomski.Application;
using Diplomski.Application.Logging;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Category;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.Implementation;
using Diplomski.Implementation.Logging;
using Diplomski.Implementation.UseCases.Commands.Brand;
using Diplomski.Implementation.UseCases.Commands.Category;
using Diplomski.Implementation.UseCases.Commands.Model;
using Diplomski.Implementation.UseCases.Queries.Brand;
using Diplomski.Implementation.UseCases.Queries.Category;
using Diplomski.Implementation.UseCases.Queries.Model;
using Diplomski.Implementation.Validators;
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

            //brands

            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IGetOneBrandQuery, EfGetOneBrandQuery>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<CreateBrandDtoValidator>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<UpdateBrandDtoValidator>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();

            //categories

            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<CreateCategoryDtoValidator>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<UpdateCategoryDtoValidator>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();


            //models

            services.AddTransient<IGetModelsQuery, EfGetModelsQuery>();
            services.AddTransient<IGetOneModelQuery, EfGetOneModelQuery>();
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
            services.AddTransient<CreateModelDtoValidator>();
            services.AddTransient<IUpdateModelCommand, EfUpdateModelCommand>();
            services.AddTransient<UpdateModelDtoValidator>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();









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
