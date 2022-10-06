using AutoMapper;
using BikeService.Data;
using BikeService.Models.Request;
using BikeService.Models.Response;
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
        private readonly IMapper _mapper;

        public ProductController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [ActionName("AddCategory")]
        [HttpPost("/add-category")]
        public async Task<ActionResult<CategoryResponse>> Add(CategoryRequest categoryRequest)
        {
            Category cate = new Category();
            cate.Name = categoryRequest.Name;
            cate.IsService = categoryRequest.IsService;
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            var categoryResponse = _mapper.Map<CategoryResponse>(cate);
            return CreatedAtAction("AddCategory", new { id = cate.Id }, categoryResponse);
        }
    }
}
