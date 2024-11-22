using Diplomski.Application;
using Diplomski.Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Diplomski.API.Core
{
    public class JwtApplicationActorProvider : IApplicationActorProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtApplicationActorProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IApplicationActor GetActor()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                return new UnauthorizedActor();
            }

            try
            {
                return new Actor
                {
                    Email = user.FindFirst("Email")?.Value,
                    FirstName = user.FindFirst("FirstName")?.Value,
                    LastName = user.FindFirst("LastName")?.Value,
                    Id = int.Parse(user.FindFirst("Id")?.Value ?? "0"),
                    RoleId = int.Parse(user.FindFirst("RoleId")?.Value ?? "0")
                };
            }
            catch
            {
                return new UnauthorizedActor();
            }
        }
    }
}
