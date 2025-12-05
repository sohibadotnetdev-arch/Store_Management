using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.CategoryDTOs;
using Store.Api.Services.CategoryService;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

      
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category = await _service.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { message = "Category not found" });

            return Ok(category);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] CategoryUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = "Category not found" });

            return Ok(updated);
        }

    
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (deleted == null)
                return NotFound(new { message = "Category not found" });

            return Ok(deleted);
        }
    }
}
