using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.AccountType;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
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

        /// <summary>
        /// Gets the modified account types from the given time.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet("modified/{lastSyncTime}")]
        public async Task<IEnumerable<AccountTypeViewModel>> GetModifiedRecords(DateTime? lastSyncTime)
        {
            return await service.Get(lastSyncTime);
        }

        // GET: AccountType/Id
        /// <summary>
        /// Gets the matching account type for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The account type</returns>
        [HttpGet("{id}")]
        public async Task<AccountTypeViewModel> Get(int id)
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
            return CreatedAtAction("Get", new { id = value.Id }, value);
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
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}