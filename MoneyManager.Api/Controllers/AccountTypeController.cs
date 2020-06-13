using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.ViewModels;
using System;
using System.Collections.Generic;

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
        // GET: AccountType
        /// <summary>
        /// Gets the account types.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet]
        public IEnumerable<AccountTypeViewModel> Get()
        {
            return new AccountTypeViewModel[]
            {
                new AccountTypeViewModel {Id = 1, Name = "Wallets",IsActive = true,CreateTime = DateTime.Now,UpdateTime = DateTime.Now},
                new AccountTypeViewModel {Id = 2, Name = "Credit card",IsActive = true,CreateTime = DateTime.Now,UpdateTime = DateTime.Now}
            };
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
            return new AccountTypeViewModel
            { Id = 1, Name = "Wallets", IsActive = true, CreateTime = DateTime.Now, UpdateTime = DateTime.Now };
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