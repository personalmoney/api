﻿using System;
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

        /// <summary>
        /// Gets the modified accounts from the given time.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet("modified/{lastSyncTime}")]
        public async Task<IEnumerable<AccountViewModel>> GetModifiedRecords(DateTime? lastSyncTime)
        {
            return await service.Get(lastSyncTime);
        }

        // GET: Account/Id
        /// <summary>
        /// Gets the matching account for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The account type</returns>
        [HttpGet("{id}")]
        public async Task<AccountViewModel> Get(int id)
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
        public async Task<IActionResult> Put(int id, [FromBody] AccountViewModel model)
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
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}