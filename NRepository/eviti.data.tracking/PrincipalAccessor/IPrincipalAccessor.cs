using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace eviti.data.tracking.PrincipalAccessor
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
        string Username { get; }
    }

    public class DefaultPrincipalAccessor : IPrincipalAccessor
    {
        public virtual ClaimsPrincipal Principal => Thread.CurrentPrincipal as ClaimsPrincipal;

        public static DefaultPrincipalAccessor Instance => new DefaultPrincipalAccessor();

        public virtual string Username => Principal.Identity.Name;
    }

    /// <summary>
    /// Allow access to the user object set in the asp.net core pipeline
    /// </summary>
    public class AspNetCorePrincipalAccessor : DefaultPrincipalAccessor
    {
        public override ClaimsPrincipal Principal => _httpContextAccessor.HttpContext?.User ?? base.Principal;
        public override string Username
        {
            get
            {
                if (Principal != null  && (Principal.Identity != null) && (string.IsNullOrWhiteSpace(Principal.Identity.Name)==false))
                { 
                    return Principal.Identity.Name;
                }
                return "anonymous";

            }
        }

        public string UsernameRequired
        {
            get
            {
                return Principal.Identity.Name;
            }
        }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCorePrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
