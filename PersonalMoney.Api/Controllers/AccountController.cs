using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.Account;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// The Account controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        // GET: Account
        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>The list accounts</returns>
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> Get()
        {
            return await service.Get();
        }

        // GET: Account/Id
        /// <summary>
        /// Gets the matching account for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The account type</returns>
        [HttpGet("{id}")]
        public async Task<AccountViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: Account
        /// <summary>
        /// Creates the account with the given information.
        /// </summary>
        /// <param name="value">The Account type data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: Account/Id
        /// <summary>
        /// Updates the account with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Account type data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] AccountViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: Account/5
        /// <summary>
        /// Deletes the Account with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.Delete(id);
        }
    }
}