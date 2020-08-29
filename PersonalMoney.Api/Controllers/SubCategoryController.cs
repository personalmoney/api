using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.SubCategory;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// The SubCategory controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public SubCategoryController(ISubCategoryService service)
        {
            this.service = service;
        }

        // GET: SubCategory
        /// <summary>
        /// Gets the SubCategories.
        /// </summary>
        /// <returns>The list SubCategories</returns>
        [HttpGet]
        public async Task<IEnumerable<SubCategoryViewModel>> Get()
        {
            return await service.Get();
        }

        // GET: SubCategory/Id
        /// <summary>
        /// Gets the matching SubCategory for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The SubCategory</returns>
        [HttpGet("{id}")]
        public async Task<SubCategoryViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: SubCategory
        /// <summary>
        /// Creates the SubCategory with the given information.
        /// </summary>
        /// <param name="value">The SubCategory data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubCategoryViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: SubCategory/Id
        /// <summary>
        /// Updates the SubCategory with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The SubCategory data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] SubCategoryViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: SubCategory/Id
        /// <summary>
        /// Deletes the SubCategory with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.Delete(id);
        }
    }
}