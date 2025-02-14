
using AspProjekat2024.Implementation.Logging;
using AspProjekat2024.Implementation.Validators;
using Diplomski.API.Core;
using Diplomski.Application;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Logging;
using Diplomski.Application.Mail;
using Diplomski.Application.UseCases.Commands;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.Application.UseCases.Commands.CategorySpecification;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.Application.UseCases.Commands.ModelVersionSpecification;
using Diplomski.Application.UseCases.Commands.Pictures;
using Diplomski.Application.UseCases.Commands.Price;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.Application.UseCases.Commands.Specification;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Cart;
using Diplomski.Application.UseCases.Queries.Category;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.Application.UseCases.Queries.Column;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.Application.UseCases.Queries.ModelVersion;
using Diplomski.Application.UseCases.Queries.ModelVersionSpecification;
using Diplomski.Application.UseCases.Queries.Pictures;
using Diplomski.Application.UseCases.Queries.Price;
using Diplomski.Application.UseCases.Queries.Products;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.Application.UseCases.Queries.Specification;
using Diplomski.Application.UseCases.Queries.Table;
using Diplomski.Application.UseCases.Queries.User;
using Diplomski.Implementation;
using Diplomski.Implementation.Logging;
using Diplomski.Implementation.UseCases.Commands.Brand;
using Diplomski.Implementation.UseCases.Commands.Cart;
using Diplomski.Implementation.UseCases.Commands.Category;
using Diplomski.Implementation.UseCases.Commands.CategorySpecification;
using Diplomski.Implementation.UseCases.Commands.Model;
using Diplomski.Implementation.UseCases.Commands.ModelVersion;
using Diplomski.Implementation.UseCases.Commands.ModelVersionSpecification;
using Diplomski.Implementation.UseCases.Commands.Pictures;
using Diplomski.Implementation.UseCases.Commands.Price;
using Diplomski.Implementation.UseCases.Commands.Role;
using Diplomski.Implementation.UseCases.Commands.Specification;
using Diplomski.Implementation.UseCases.Commands.User;
using Diplomski.Implementation.UseCases.Queries.Brand;
using Diplomski.Implementation.UseCases.Queries.Cart;
using Diplomski.Implementation.UseCases.Queries.Category;
using Diplomski.Implementation.UseCases.Queries.CategorySpecification;
using Diplomski.Implementation.UseCases.Queries.Column;
using Diplomski.Implementation.UseCases.Queries.Model;
using Diplomski.Implementation.UseCases.Queries.ModelVersion;
using Diplomski.Implementation.UseCases.Queries.ModelVersionSpecification;
using Diplomski.Implementation.UseCases.Queries.Pictures;
using Diplomski.Implementation.UseCases.Queries.Price;
using Diplomski.Implementation.UseCases.Queries.Product;
using Diplomski.Implementation.UseCases.Queries.Role;
using Diplomski.Implementation.UseCases.Queries.Specification;
using Diplomski.Implementation.UseCases.Queries.Tables;
using Diplomski.Implementation.UseCases.Queries.User;
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

            //specifications

            services.AddTransient<IGetSpecificationsQuery, EfGetSpecificationsQuery>();
            services.AddTransient<IGetOneSpecificationQuery, EfGetOneSpecificationQuery>();
            services.AddTransient<ICreateSpecificationCommand, EfCreateSpecificationCommand>();
            services.AddTransient<CreateSpecificationDtoValidator>();
            services.AddTransient<IUpdateSpecificationCommand, EfUpdateSpecificationCommand>();
            services.AddTransient<UpdateSpecificationDtoValidator>();
            services.AddTransient<IDeleteSpecificationCommand, EfDeleteSpecificationCommand>();

            //roles

            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IGetOneRoleQuery, EfGetOneRoleQuery>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<CreateRoleDtoValidator>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<UpdateRoleDtoValidator>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();

            //users


            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<UpdateUserDtoValidator>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();


            //model versions

            services.AddTransient<IGetModelVersionsQuery, EfGetModelVersionsQuery>();
            services.AddTransient<IGetOneModelVersionQuery, EfGetOneModelVersionQuery>();
            services.AddTransient<ICreateModelVersionCommand, EfCreateModelVersionCommand>();
            services.AddTransient<CreateModelVersionDtoValidator>();
            services.AddTransient<IUpdateModelVersionCommand, EfUpdateModelVersionCommand>();
            services.AddTransient<UpdateModelVersionDtoValidator>();
            services.AddTransient<IDeleteModelVersionCommand, EfDeleteModelVersionCommand>();

            //pictures

            services.AddTransient<IGetPicturesQuery, EfGetPicturesQuery>();
            services.AddTransient<IGetOnePictureQuery, EfGetOnePictureQuery>();
            services.AddTransient<ICreatePictureCommand, EfCreatePictureCommand>();
            services.AddTransient<CreatePictureDtoValidator>();
            services.AddTransient<IUpdatePictureCommand, EfUpdatePictureCommand>();
            services.AddTransient<IDeletePictureCommand, EfDeletePictureCommand>();
             
            //categorySpecifications

            services.AddTransient<IGetCategorySpecificationsQuery, EfGetCategorySpecificationsQuery>();
            services.AddTransient<IGetOneCategorySpecificationQuery, EfGetOneCategorySpecificationQuery>();
            services.AddTransient<ICreateCategorySpecificationCommand, EfCreateCategorySpecificationCommand>();
            services.AddTransient<CreateCategorySpecificationDtoValidator>();
            services.AddTransient<IUpdateCategorySpecificationCommand, EfUpdateCategorySpecificationCommand>();
            services.AddTransient<UpdateCategorySpecificationDtoValidator>();
            services.AddTransient<IDeleteCategorySpecificationCommand, EfDeleteCategorySpecificationCommand>();

            //modelVersionSpecifications

            services.AddTransient<IGetModelVersionSpecificationsQuery, EfGetModelVersionSpecificationsQuery>();
            services.AddTransient<IGetOneModelVersionSpecificationQuery, EfGetOneModelVersionSpecificationQuery>();
            services.AddTransient<ICreateModelVersionSpecificationCommand, EfCreateModelVersionSpecificationCommand>();
            services.AddTransient<CreateModelVersionSpecificationDtoValidator>();
            services.AddTransient<IUpdateModelVersionSpecificationCommand, EfUpdateModelVersionSpecificationCommand>();
            services.AddTransient<UpdateModelVersionSpecificationDtoValidator>();
            services.AddTransient<IDeleteModelVersionSpecificationCommand, EfDeleteModelVersionSpecificationCommand>();

            //Prices

            services.AddTransient<IGetPricesQuery, EfGetPricesQuery>();
            services.AddTransient<IGetOnePriceQuery, EfGetOnePriceQuery>();
            services.AddTransient<ICreatePriceCommand, EfCreatePriceCommand>();
            services.AddTransient<CreatePriceDtoValidator>();
            services.AddTransient<IUpdatePriceCommand, EfUpdatePriceCommand>();
            services.AddTransient<UpdatePriceDtoValidator>();
            services.AddTransient<IDeletePriceCommand, EfDeletePriceCommand>();

            //products

            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>();
            services.AddTransient<IGetOneProductQuery, EfGetOneProductQuery>();

            //carts

            services.AddTransient<IGetCartsQuery, EfGetCartsQuery>();
            services.AddTransient<IGetOneCartQuery, EfGetOneCartQuery>();
            services.AddTransient<ICreateCartCommand, EfCreateCartCommand>();










            services.AddTransient<IEmailService>(provider =>
                new EmailService("smtp.gmail.com", 587, "marko.markovic.33.21@ict.edu.rs", "huvumdbwlqayjfzm"));

            //tables

            services.AddTransient<IGetTablesQuery, EfGetTablesQuery>();
            services.AddTransient<IGetColumnsQuery, EfGetColumnsQuery>();
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
