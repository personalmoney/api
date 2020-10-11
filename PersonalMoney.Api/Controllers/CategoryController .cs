using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.Category;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// The Category controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: Category
        /// <summary>
        /// Gets the Categories.
        /// </summary>
        /// <returns>The list categories</returns>
        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> Get()
        {
            return await service.Get();
        }

        /// <summary>
        /// Gets the modified categories from the given time.
        /// </summary>
        /// <returns>The list account of types</returns>
        [HttpGet("modified/{lastSyncTime}")]
        public async Task<IEnumerable<CategoryViewModel>> GetModifiedRecords(DateTime? lastSyncTime)
        {
            return await service.Get(lastSyncTime);
        }

        // GET: Category/Id
        /// <summary>
        /// Gets the matching Category for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Category</returns>
        [HttpGet("{id}")]
        public async Task<CategoryViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: Category
        /// <summary>
        /// Creates the Category with the given information.
        /// </summary>
        /// <param name="value">The Category data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: Category/Id
        /// <summary>
        /// Updates the Category with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Category data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CategoryViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: Category/Id
        /// <summary>
        /// Deletes the Category with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.Delete(id);
        }
    }
}