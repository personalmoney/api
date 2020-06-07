using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Service active");
        }
    }
}