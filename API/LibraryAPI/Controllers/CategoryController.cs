using Application.Category;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;   
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                return Ok(category); // Return the category if found (200 OK)
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return 404 Not Found with message
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryModel category)
        {
            try 
            {
                var createdCategory = await _categoryService.CreateCategory(category);
                return Ok(createdCategory);
            }
            catch (DbUpdateException ex) 
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
