using AutoMapper;
using BikeService.Models.Request;
using BikeService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("get-all-category")]
        public IActionResult getAllCategory()
        {
            var category = _categoryService.GetAll();
            return Ok(category);
        }

        [HttpGet("search-category/{name}")]
        public IActionResult searchByName(string name)
        {
            var category = _categoryService.GetByName(name);
            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CategoryRequest categoryRequest)
        {
            _categoryService.Create(categoryRequest);
            return Ok(categoryRequest);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryRequest categoryRequest)
        {
            _categoryService.Update(id, categoryRequest);
            return Ok(categoryRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok(id);
        }
    }
}
