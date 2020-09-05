using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalMoney.Api.Services.Tag;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Controllers
{
    /// <summary>
    /// The Tag controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public TagController(ITagService service)
        {
            this.service = service;
        }

        // GET: Tag
        /// <summary>
        /// Gets the Tags.
        /// </summary>
        /// <returns>The list tags</returns>
        [HttpGet]
        public async Task<IEnumerable<TagViewModel>> Get()
        {
            return await service.Get();
        }

        // GET: Tag/Id
        /// <summary>
        /// Gets the matching Tag for the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Tag</returns>
        [HttpGet("{id}")]
        public async Task<TagViewModel> Get(string id)
        {
            return await service.Get(id);
        }

        // POST: Tag
        /// <summary>
        /// Creates the Tag with the given information.
        /// </summary>
        /// <param name="value">The Tag data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagViewModel value)
        {
            value = await service.Create(value);
            if (value == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT: Tag/Id
        /// <summary>
        /// Updates the Tag with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The Tag data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] TagViewModel model)
        {
            model = await service.Update(id, model);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        // DELETE: Tag/Id
        /// <summary>
        /// Deletes the Tag with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.Delete(id);
        }
    }
}