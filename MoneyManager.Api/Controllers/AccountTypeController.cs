using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.Services.AccountType;
using MoneyManager.Api.ViewModels;

namespace MoneyManager.Api.Controllers
{
    /// <summary>
    /// The Account Type controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public AccountTypeController(IAccountTypeService service)
        {
            this.service = service;
        }

        // GET: AccountType
        /// <summary>
        /// Gets the account types.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet]
        public async Task<IEnumerable<AccountTypeViewModel>> Get()
        {
            return await service.Get();
        }

        // GET: AccountType/Id
        /// <summary>
        /// Gets the matching account type for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The account type</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<AccountTypeViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: AccountType
        /// <summary>
        /// Creates the account type with the given information.
        /// </summary>
        /// <param name="value">The Account type data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountTypeViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return Ok(value);
        }

        // PUT: AccountType/Id
        /// <summary>
        /// Updates the account type with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Account type data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] AccountTypeViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: AccountType/5
        /// <summary>
        /// Deletes the Account type with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}