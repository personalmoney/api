using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.Transaction;
using PersonalMoney.Api.ViewModels;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// Transaction controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public TransactionController(ITransactionService service)
        {
            this.service = service;
        }

        // GET: Transaction
        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <returns>The list Transactions</returns>
        [HttpGet]
        public async Task<PagingResponse<TransactionViewModel>> Get([FromQuery] TransactionSearchViewModel request)
        {
            return await service.Get(request);
        }

        /// <summary>
        /// Gets the modified Transactions from the given time.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet("modified")]
        public async Task<PagingResponse<TransactionViewModel>> GetModifiedRecords([FromQuery] TransactionSearchViewModel request)
        {
            return await service.GetModified(request);
        }

        // GET: Transaction/Id
        /// <summary>
        /// Gets the matching Transaction for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Transaction</returns>
        [HttpGet("{id}")]
        public async Task<TransactionViewModel> Get(int id)
        {
            return await service.Get(id);
        }

        // POST: Transaction
        /// <summary>
        /// Creates the Transaction with the given information.
        /// </summary>
        /// <param name="value">The Transaction data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: Transaction/Id
        /// <summary>
        /// Updates the Transaction with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Transaction data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TransactionViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: Transaction/Id
        /// <summary>
        /// Deletes the Transaction with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}