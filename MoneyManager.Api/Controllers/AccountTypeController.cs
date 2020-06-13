using System.Collections.Generic;
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
        public IEnumerable<AccountTypeViewModel> Get()
        {
            return service.Get();
        }

        // GET: AccountType/5
        /// <summary>
        /// Gets the matching account type for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The account type</returns>
        [HttpGet("{id}", Name = "Get")]
        public AccountTypeViewModel Get(int id)
        {
            return service.Get(id);
        }

        // POST: AccountType
        /// <summary>
        /// Creates the account type with the given information.
        /// </summary>
        /// <param name="value">The Account type data.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AccountTypeViewModel value)
        {
            return Created("Get", value.Id);
        }

        // PUT: AccountType/5
        /// <summary>
        /// Updates the account type with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The Account type data.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AccountTypeViewModel value)
        {
        }

        // DELETE: AccountType/5
        /// <summary>
        /// Deletes the Account type with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}