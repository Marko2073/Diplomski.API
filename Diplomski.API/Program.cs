using AspProjekat2024.API.Core;
using Diplomski.API;
using Diplomski.API.Core;
using Diplomski.Application;
using Diplomski.DataAccess;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);

builder.Services.AddSingleton(settings.Jwt);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DatabaseContext>(x => new DatabaseContext(settings.ConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddUseCases();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ITokenStorage, InMemoryTokenStorage>();


//builder.Services.AddTransient<IApplicationActorProvider>(x =>
//{
//    var accessor = x.GetService<IHttpContextAccessor>();

//    var request = accessor.HttpContext.Request;

//    var authHeader = request.Headers.Authorization.ToString();

//    var context = x.GetService<DatabaseContext>();

//    return new JwtApplicationActorProvider(authHeader);
//});
//builder.Services.AddTransient<IApplicationActor>(x =>
//{
//    var accessor = x.GetService<IHttpContextAccessor>();
//    if (accessor.HttpContext == null)
//    {
//        return new UnauthorizedActor();
//    }

//    return x.GetService<IApplicationActorProvider>().GetActor();
//});
builder.Services.AddTransient<IApplicationActorProvider, JwtApplicationActorProvider>();
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var provider = x.GetService<IApplicationActorProvider>();
    return provider.GetActor();
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(cfg =>
//{
//    cfg.RequireHttpsMetadata = false;
//    cfg.SaveToken = true;
//    cfg.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = settings.Jwt.Issuer,
//        ValidateIssuer = true,
//        ValidAudience = "Any",
//        ValidateAudience = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
//        ValidateIssuerSigningKey = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//    };
//    cfg.Events = new JwtBearerEvents
//    {
//        OnTokenValidated = context =>
//        {
//            // Token dohvatamo iz Authorization header-a
//            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

//            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

//            if (!storage.Exists(tokenId))
//            {
//                context.Fail("Invalid token");
//            }

//            return Task.CompletedTask;
//        }
//    };
//});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            // Ako token nije validan, loguj grešku
            Console.WriteLine($"Invalid token: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            var tokenId = context.HttpContext.Request.GetTokenId();
            var storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

            if (tokenId.HasValue && !storage.Exists(tokenId.Value))
            {
                context.Fail("Token is no longer valid.");
            }

            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
