using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.ViewModels;
using System;
using System.Collections.Generic;

namespace MoneyManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        // GET: AccountType
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
        [HttpGet("{id}", Name = "Get")]
        public AccountTypeViewModel Get(int id)
        {
            return new AccountTypeViewModel
            { Id = 1, Name = "Wallets", IsActive = true, CreateTime = DateTime.Now, UpdateTime = DateTime.Now };
        }

        // POST: AccountType
        [HttpPost]
        public void Post([FromBody] AccountTypeViewModel value)
        {
        }

        // PUT: AccountType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AccountTypeViewModel value)
        {
        }

        // DELETE: AccountType/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}