using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PersonalMoney.Api.Services
{
    /// <summary>
    /// User resolver service
    /// </summary>
    public class UserResolverService
    {
        private readonly IHttpContextAccessor context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserResolverService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserResolverService(IHttpContextAccessor context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            ClaimsPrincipal currentUser = context.HttpContext?.User;
            if (currentUser?.Claims == null)
            {
                return string.Empty;
            }
            return currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}