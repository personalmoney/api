using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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