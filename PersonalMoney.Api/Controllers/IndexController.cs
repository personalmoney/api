using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// Index controller to check the service health status
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserResolverService userResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="userResolver">The user resolver.</param>
        public IndexController(IUserService userService, UserResolverService userResolver)
        {
            this.userService = userService;
            this.userResolver = userResolver;
        }

        /// <summary>
        /// Gets this service health status.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Service active");
        }

        /// <summary>
        /// Create the user.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(UserViewModel model)
        {
            model.UserId = userResolver.GetUserId();
            userService.CreateUser(model);
            return Ok();
        }

        /// <summary>
        /// Gets the Status of this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status")]
        [AllowAnonymous]
        public ActionResult Status()
        {
            return Ok("Service active");
        }

        /// <summary>
        /// Gets the Version of the current deployment.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Version")]
        [AllowAnonymous]
        public ActionResult Version()
        {
            return Ok(GetType().Assembly.GetName().Version!.ToString());
        }
    }
}