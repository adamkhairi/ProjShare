using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjShare.API.Services.Categories;
using ProjShare.Shared.Models;

namespace ProjShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _category;

        public CategoryController(ICategoryServices category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            return await _category.GetAll();
        }

        [HttpGet("GetCategory")]
        // [Authorize(Roles = "Admin")]
        public async Task<Category> GetCategory(string id)
        {
            var cat = await _category.Get(id);
            return cat;
        }

        [HttpPost("AddCategory")]
        // [Authorize(Roles = "Client")]
        public async Task<IActionResult> AddCategories([FromForm] Category category, List<IFormFile> image)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _category.Post(category, image);

            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _category.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [FromForm] Category category, List<IFormFile> image)
        {
            if (id != category.Id) return BadRequest();

            await _category.Put(category, image);
            return Ok(category);
        }
    }
}