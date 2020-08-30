using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.Payee;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// The Payee controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class PayeeController : ControllerBase
    {
        private readonly IPayeeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayeeController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public PayeeController(IPayeeService service)
        {
            this.service = service;
        }

        // GET: Payee
        /// <summary>
        /// Gets the Payees.
        /// </summary>
        /// <returns>The list payees</returns>
        [HttpGet]
        public async Task<IEnumerable<PayeeViewModel>> Get()
        {
            return await service.Get();
        }

        // GET: Payee/Id
        /// <summary>
        /// Gets the matching Payee for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Payee</returns>
        [HttpGet("{id}")]
        public async Task<PayeeViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: Payee
        /// <summary>
        /// Creates the Payee with the given information.
        /// </summary>
        /// <param name="value">The Payee data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PayeeViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: Payee/Id
        /// <summary>
        /// Updates the Payee with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Payee data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PayeeViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: Payee/Id
        /// <summary>
        /// Deletes the Payee with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.Delete(id);
        }
    }
}