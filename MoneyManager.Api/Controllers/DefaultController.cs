using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Api.Controllers
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
    }
}