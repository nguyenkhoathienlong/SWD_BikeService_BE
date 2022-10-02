using BikeService.Data;
using BikeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        [ActionName("AddCategory")]
        [HttpPost("/add-category")]
        public async Task<ActionResult<Category>> Add(Category cate)
        {
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddCategory", new { id = cate.Id }, cate);
        }
    }
}
